using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityResidence.Models
{
    public class ResidenceHall
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        public List<Room> Rooms { get; set; }

        public List<Employee> Employees { get; set; }


        public ResidenceHall() { }   // EF needs this


        public ResidenceHall(string adress)
        {
            Id = Guid.NewGuid();
            Adress = adress;
        }

        public override bool Equals(object obj)
        {
            var hall = obj as ResidenceHall;
            return hall != null && Id.Equals(hall.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
