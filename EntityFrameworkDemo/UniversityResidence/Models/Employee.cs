using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityResidence.Models
{
    public class Employee
    {
        [Key]
        public string Oib { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Position { get; set; }

        public List<ResidenceHall> WorkPlace { get; set; }


        public Employee() { }   // EF needs this


        public Employee(string oib)
        {
            Oib = oib;
        }

        public override bool Equals(object obj)
        {
            var emp = obj as Employee;
            return emp != null && Oib.Equals(emp.Oib);
        }

        public override int GetHashCode()
        {
            return Oib.GetHashCode();
        }
    }
}
