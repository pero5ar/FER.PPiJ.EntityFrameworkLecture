using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;

namespace UniversityResidence.Models
{
    public class Student
    {
        [Key]
        public string Jmbag { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfEnrollment { get; set; }

        public Room Room { get; set; }


        public override bool Equals(object obj)
        {
            var stud = obj as Student;
            return stud != null && Jmbag.Equals(stud.Jmbag);
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }
    }
}
