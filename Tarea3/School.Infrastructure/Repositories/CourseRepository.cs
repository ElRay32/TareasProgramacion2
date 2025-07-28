using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Infrastructure.Context;
using School.Infrastructure.Exceptions;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Models;

namespace School.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public CourseRepository(SchoolContext context) : base(context) { }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var data = await _context.Cursos.Include(c => c.Department).ToListAsync();
            return data.Select(m => new Course {
                Id = m.Id,
                Title = m.Title,
                Credits = m.Credits,
                DepartmentId = m.DepartmentId,
                Department = new Department {
                    Id = m.Department.Id,
                    Name = m.Department.Name
                }
            });
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            var m = await _context.Cursos.Include(c => c.Department).FirstOrDefaultAsync(c => c.Id == id);
            if (m == null) throw new CourseException($"Course {id} not found");
            return new Course {
                Id = m.Id,
                Title = m.Title,
                Credits = m.Credits,
                DepartmentId = m.DepartmentId,
                Department = new Department { Id = m.Department.Id, Name = m.Department.Name }
            };
        }

        public async Task AddAsync(Course entity)
        {
            var model = new CursoModel {
                Title = entity.Title,
                Credits = entity.Credits,
                DepartmentId = entity.DepartmentId
            };
            await _context.Cursos.AddAsync(model);
            await _context.SaveChangesAsync();
            entity.Id = model.Id;
        }

        public void Update(Course entity)
        {
            var model = _context.Cursos.Find(entity.Id)
                ?? throw new CourseException($"Course {entity.Id} not found");
            model.Title = entity.Title;
            model.Credits = entity.Credits;
            model.DepartmentId = entity.DepartmentId;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.Cursos.Find(id)
                ?? throw new CourseException($"Course {id} not found");
            _context.Cursos.Remove(model);
            _context.SaveChanges();
        }
    }
}
