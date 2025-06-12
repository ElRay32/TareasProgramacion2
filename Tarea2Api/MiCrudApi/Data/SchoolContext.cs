using Microsoft.EntityFrameworkCore;
using MiCrudApi.Models;

namespace MiCrudApi.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; } = null!;
    }
}