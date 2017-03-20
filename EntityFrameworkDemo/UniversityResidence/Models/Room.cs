using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityResidence.Models
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Capacity { get; set; }

        public ResidenceHall Hall { get; set; }

        public List<Student> Occupants { get; set; }


        public override bool Equals(object obj)
        {
            var room = obj as Room;
            return room != null && Id.Equals(room.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
