using System;
using System.Linq;
using UniversityResidence;
using UniversityResidence.Interfaces;
using UniversityResidence.Models;
using UniversityResidence.Repositories;

namespace UniversityResidenceConsoleApp
{
    class Program
    {
        // this is a BAD practice
        private const string _connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = UniversityResidenceDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        static void Main(string[] args)
        {
            using (var db = new UniversityResidenceDbContext(_connectionString))
            {
                var employeeRepository = new EmployeeRepository(db);
                employeeRepository.GetWorksAs("Kuhar/ica").ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));

                var residenceHallRepository = new ResidenceHallRepository(db);
                var hall = new ResidenceHall()
                {
                    Name = "Novi dom",
                    Adress = "negdje je"
                };
                // residenceHallRepository.Add(hall);
                /*var h = residenceHallRepository.Get(hall.Id);
                residenceHallRepository.Remove(h);*/

                var studentRepository = new StudentRepository(db);
                var roomRepository = new RoomRepository(db);
                var stud = studentRepository.Get("00250724081");
                if (stud.FindARoom(roomRepository)) studentRepository.Update(stud);
            }
        }
        
    }
}
