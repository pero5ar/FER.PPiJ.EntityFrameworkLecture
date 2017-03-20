using System.Linq;
using UniversityResidence.Interfaces;
using UniversityResidence.Models;

namespace UniversityResidenceConsoleApp
{
    public static class Extensions
    {
        public static bool FindARoom(this Student student, IRoomRepository roomRepository)
        {
            var rooms = roomRepository.GetFree();
            if (rooms.Count == 0) return false;
            var room = rooms.First();
            student.Room = room;
            return true;
        }
    }
}
