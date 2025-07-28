using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Models;

namespace School.Infrastructure.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options) { }

        public DbSet<CursoModel> Cursos       { get; set; } = null!;
        public DbSet<DepartmentModel> Departments { get; set; } = null!;
    }
}
