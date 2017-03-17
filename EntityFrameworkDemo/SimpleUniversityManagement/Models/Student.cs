using System.Collections.Generic;

namespace SimpleUniversityManagement.Models
{
    public class Student
    {
        public string Jmbag { get; set; }

        public string Name { get; set; }

        public Professor Mentor { get; set; }

        public List<Class> EnrolledClasses { get; set; }
    }
}
