namespace School.Infrastructure.Models
{
    public class CursoModel
    {
        public int Id           { get; set; }
        public string Title     { get; set; } = string.Empty;
        public int Credits      { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentModel Department { get; set; } = null!;
    }
}
