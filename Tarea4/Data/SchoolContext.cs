using Microsoft.EntityFrameworkCore;
using Tarea2Api.Models;

namespace Tarea2Api.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        // Única propiedad DbSet para Students:
        public DbSet<Student> Students { get; set; } = null!;
    }
}

