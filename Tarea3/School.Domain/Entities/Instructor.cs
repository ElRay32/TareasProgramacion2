using School.Domain.Core;

namespace School.Domain.Entities
{
    public class Instructor : Person
    {
        public int DepartmentId   { get; set; }
        public Department Department { get; set; } = null!;
    }
}
