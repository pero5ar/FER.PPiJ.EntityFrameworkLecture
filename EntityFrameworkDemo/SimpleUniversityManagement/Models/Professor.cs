using System.Collections.Generic;

namespace SimpleUniversityManagement.Models
{
    public class Professor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Student> MentoredStudents { get; set; }

        public List<Class> ClassesTeaching { get; set; }
    }
}
