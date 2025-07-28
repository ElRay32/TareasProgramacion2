using School.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Infrastructure.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task AddAsync(Course entity);
        void Update(Course entity);
        void Delete(int id);
    }
}
