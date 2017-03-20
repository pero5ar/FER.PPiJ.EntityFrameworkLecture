using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UniversityResidence.Models;

namespace UniversityResidence
{
    // TODO: refactor
    public static class Utility
    {
        // not perfect, if you get an error, clear and try again
        public static void GenerateData(this UniversityResidenceDbContext context)
        {
            var halls = GenerateHalls();
            var rooms = GenerateRooms(halls, 30);
            var students = GenerateStudents(rooms);
            var emplyees = GenerateEmployees(halls, 10);
            halls.ForEach(h => context.Halls.Add(h));
            rooms.ForEach(r => context.Rooms.Add(r));
            students.ForEach(s => context.Students.Add(s));
            emplyees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
        }

        public static void ClearData(this UniversityResidenceDbContext context)
        {
            context.Employees.RemoveAll();
            context.Halls.RemoveAll();
            context.Rooms.RemoveAll();
            context.Students.RemoveAll();
            context.SaveChanges();
        }

        public static void RemoveAll<T>(this IDbSet<T> table) where T:class
        {
            var rows = new List<T>(table);
            rows.ForEach(r => table.Remove(r));
        }

        private static List<ResidenceHall> GenerateHalls()
        {
            return new List<ResidenceHall>()
                {
                    new ResidenceHall("Ulica Doma Alfa 1")
                    {
                        Name = "Dom Alfa"
                    },
                    new ResidenceHall("Ulica Doma Beta 1")
                    {
                        Name = "Dom Beta"
                    },
                    new ResidenceHall("Ulica Doma Gama 1")
                    {
                        Name = "Dom Gama"
                    }
                };
        }

        private static List<Room> GenerateRooms(List<ResidenceHall> halls, int n)
        {
            var rand = new Random();
            var rooms = new List<Room>();
            for (int i = 0; i < n; i++)
            {
                rooms.Add(new Room(rand.Next(4))
                    {
                        Hall = halls[rand.Next(halls.Count - 1)],
                        Occupants = new List<Student>()
                    }
                );
            }
            return rooms;
        }

        private static List<Student> GenerateStudents(List<Room> rooms)
        {
            var rand = new Random();
            return _listOfNames.Select(name =>
                {
                    var room = rooms[rand.Next(rooms.Count - 1)];
                    if (room.Occupants.Count >= room.Capacity) room = null;
                    var stud = new Student($"00{rand.Next(10111111, 999999999)}")
                    {
                        FirstName = name.Split()[0],
                        LastName = name.Split()[1],
                        DateOfEnrollment =
                            new DateTime(DateTime.Today.Year - rand.Next(5), rand.Next(1, 12), rand.Next(1, 28)),
                        Room = room
                    };
                    room?.Occupants.Add(stud);
                    return stud;
                }
            ).ToList();
        }

        private static List<Employee> GenerateEmployees(List<ResidenceHall> halls, int n)
        {
            var rand = new Random();
            var employees = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                employees.Add(new Employee($"{rand.Next(12345, 98765)}{rand.Next(012345, 987654)}")
                {
                    FirstName = _listOfNames[rand.Next(_listOfNames.Count - 1)].Split()[0],
                    LastName = _listOfNames[rand.Next(_listOfNames.Count - 1)].Split()[1],
                    Position = _listOfPositions[rand.Next(_listOfPositions.Count - 1)],
                    WorkPlace = new List<ResidenceHall>()
                    {
                        halls[rand.Next(halls.Count - 1)],
                        halls[rand.Next(halls.Count - 1)]
                    }.Distinct().ToList()
                });
            }
            return employees;
        }

        private static readonly List<string> _listOfNames = new List<string>()
        {
            "Lorinda Hamsher",
            "Austin Cabello",
            "Cyrus Moorman",
            "Fay Lurie",
            "Princess Halper",
            "Margarito Brunk",
            "Arlena Phinney",
            "Valda Bender",
            "Sunshine Gioia",
            "Berenice Khouri",
            "Mellissa Rohrer",
            "Thuy Schippers",
            "Chuck Purdy",
            "Paulina Nogle",
            "Sarita Sober",
            "Sherise Fraley",
            "Corina Porco",
            "Lanie Nations",
            "Serafina Cevallos",
            "Joetta Chaffee",
            "Samella Pugh",
            "Awilda Beaubien",
            "Ulysses Mazzarella",
            "Hang Sumrall",
            "Jarod Islas",
            "Vada Seelye",
            "Deanna Luther",
            "Micheline Woodford",
            "Brenda Tiner",
            "Carmelia Moctezuma",
            "Noreen Berber",
            "Terrie Meikle",
            "Angelic Ohare",
            "Leo Mccullum",
            "Sheri Mossman",
            "Lorelei Favela",
            "Emmie Lush",
            "Ben Eddington",
            "Belen Bourland",
            "Jacinta Ha",
            "Diann Bankhead",
            "Vince Hamblin",
            "Grace Bullard",
            "Celinda Panek",
            "Janette Faul",
            "Alisia Trace",
            "Ezekiel Heinecke",
            "Regena Tassin",
            "Rogelio Latham",
            "Rae Bourbeau"
        };

        private static readonly List<string> _listOfPositions = new List<string>()
        {
            "kuhar/ica",
            "sobar/ica",
            "cistac/ica",
            "konobar/ica",
            "direktor/ica"
        };
    }
}
