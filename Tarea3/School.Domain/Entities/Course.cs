using School.Domain.Core;

namespace School.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Title       { get; set; } = string.Empty;
        public int Credits        { get; set; }
        public int DepartmentId   { get; set; }
        public Department Department { get; set; } = null!;
    }
}
