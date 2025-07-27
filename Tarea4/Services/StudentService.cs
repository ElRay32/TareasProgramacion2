using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea2Api.Core;
using Tarea2Api.Contract;
using Tarea2Api.Data;
using Tarea2Api.Dtos;
using Tarea2Api.Models;

namespace Tarea2Api.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly SchoolContext _context;
        public StudentService(SchoolContext context) => _context = context;

        public async Task<ServiceResult<IEnumerable<StudentDto>>> GetAllAsync()
        {
            var list = await _context.Students
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    EnrollmentDate = s.EnrollmentDate
                })
                .ToListAsync();

            return OkResult<IEnumerable<StudentDto>>(list);
        }

        public async Task<ServiceResult<StudentDto>> GetByIdAsync(int id)
        {
            var s = await _context.Students.FindAsync(id);
            if (s == null)
                return ErrorResult<StudentDto>("Estudiante no encontrado.");

            var dto = new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                EnrollmentDate = s.EnrollmentDate
            };

            return OkResult(dto);
        }

        public async Task<ServiceResult<StudentDto>> CreateAsync(StudentDto dto)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(dto.Name))
                return ErrorResult<StudentDto>("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Email) || !dto.Email.Contains("@"))
                return ErrorResult<StudentDto>("Email inválido.");
            if (dto.EnrollmentDate == default)
                return ErrorResult<StudentDto>("Fecha de inscripción inválida.");

            var entity = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                EnrollmentDate = dto.EnrollmentDate
            };

            _context.Students.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return OkResult(dto, "Estudiante creado correctamente.");
        }

        public async Task<ServiceResult<StudentDto>> UpdateAsync(int id, StudentDto dto)
        {
            var s = await _context.Students.FindAsync(id);
            if (s == null)
                return ErrorResult<StudentDto>("Estudiante no encontrado.");

            // Validaciones
            if (string.IsNullOrWhiteSpace(dto.Name))
                return ErrorResult<StudentDto>("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Email) || !dto.Email.Contains("@"))
                return ErrorResult<StudentDto>("Email inválido.");

            s.Name = dto.Name;
            s.Email = dto.Email;
            s.EnrollmentDate = dto.EnrollmentDate;

            await _context.SaveChangesAsync();
            return OkResult(dto, "Estudiante actualizado correctamente.");
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var s = await _context.Students.FindAsync(id);
            if (s == null)
                return ErrorResult<bool>("Estudiante no encontrado.");

            _context.Students.Remove(s);
            await _context.SaveChangesAsync();
            return OkResult(true, "Estudiante eliminado correctamente.");
        }
    }
}
