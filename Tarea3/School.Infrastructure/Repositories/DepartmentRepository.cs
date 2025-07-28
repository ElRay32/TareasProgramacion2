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
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(SchoolContext context) : base(context) { }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var data = await _context.Departments.Include(d => d.Cursos).ToListAsync();
            return data.Select(m => new Department {
                Id = m.Id,
                Name = m.Name
            });
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            var m = await _context.Departments.Include(d => d.Cursos).FirstOrDefaultAsync(d => d.Id == id);
            if (m == null) throw new DepartmentException($"Department {id} not found");
            return new Department {
                Id = m.Id,
                Name = m.Name
            };
        }

        public async Task AddAsync(Department entity)
        {
            var model = new DepartmentModel {
                Name = entity.Name
            };
            await _context.Departments.AddAsync(model);
            await _context.SaveChangesAsync();
            entity.Id = model.Id;
        }

        public void Update(Department entity)
        {
            var model = _context.Departments.Find(entity.Id)
                ?? throw new DepartmentException($"Department {entity.Id} not found");
            model.Name = entity.Name;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.Departments.Find(id)
                ?? throw new DepartmentException($"Department {id} not found");
            _context.Departments.Remove(model);
            _context.SaveChanges();
        }
    }
}
