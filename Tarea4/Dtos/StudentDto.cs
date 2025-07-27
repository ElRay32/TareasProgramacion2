using System;

namespace Tarea2Api.Dtos
{
    public class StudentDto : DtoBase
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
    }
}
