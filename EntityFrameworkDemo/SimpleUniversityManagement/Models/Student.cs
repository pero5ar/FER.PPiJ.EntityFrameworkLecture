using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleUniversityManagement.Models
{
    public class Student
    {
        [Key]
        public string Jmbag { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        public Professor Mentor { get; set; }

        public List<Class> EnrolledClasses { get; set; }
    }
}
