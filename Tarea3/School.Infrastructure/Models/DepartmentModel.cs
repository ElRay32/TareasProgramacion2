using System.Collections.Generic;

namespace School.Infrastructure.Models
{
    public class DepartmentModel
    {
        public int Id          { get; set; }
        public string Name     { get; set; } = string.Empty;
        public ICollection<CursoModel> Cursos { get; set; } = new List<CursoModel>();
    }
}
