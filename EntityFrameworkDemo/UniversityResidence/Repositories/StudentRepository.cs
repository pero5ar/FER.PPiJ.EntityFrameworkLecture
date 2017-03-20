using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversityResidence.Exceptions;
using UniversityResidence.Interfaces;
using UniversityResidence.Models;

namespace UniversityResidence.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(UniversityResidenceDbContext context) : base(context, context.Students)
        {
        }

        public override bool Add(Student item)
        {
            var room = item?.Room;
            if (room != null && room.Occupants.Count == room.Capacity) throw new RoomFullException($"Room {room.Id} is full");
            return base.Add(item);
        }

        public Student Get(string jmbag)
        {
            return _table.FirstOrDefault(s => s.Jmbag.Equals(jmbag));
        }

        public List<Student> GetAllWithRooms()
        {
            return _table.Include(s => s.Room).ToList();
        }
    }
}
