using System.Collections.Generic;

namespace SimpleUniversityManagement.Models
{
    public class Class
    {
        public int Id { get; set; }

        public int Ects { get; set; }

        public string Name { get; set; }

        public List<Professor> Professors { get; set; }

        public List<Student> EnrolledStudents { get; set; }
    }
}
