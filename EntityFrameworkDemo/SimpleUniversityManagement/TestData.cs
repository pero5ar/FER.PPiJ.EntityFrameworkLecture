using System;
using System.Collections.Generic;
using SimpleUniversityManagement.Models;

namespace SimpleUniversityManagement
{
    public class TestData
    {
        private readonly List<string> _names = new List<string>()
        {
            "Ivo",
            "Mate",
            "Pero",
            "Mare",
            "Kate",
            "Jure",
            "Jere",
            "Frane",
            "Ante",
            "Ana",
            "Sara",
            "Sonja",
            "Morana",
            "Ivan",
            "Marko",
            "Petar",
            "Marin",
            "Marina",
            "Filip",
            "Nikola",
            "Luce",
            "Lucija",
            "Netko"
        };

        public List<Professor> Professors { get; }
        public List<Student> Students { get; }

        public TestData(Random rand)
        {
            Professors = new List<Professor>
            {
                new Professor()
                {
                    Name = "Baltazar"
                },
                new Professor()
                {
                    Name = "X"
                }
            };
            Students = new List<Student>();
            foreach (var name in _names)
            {
                Students.Add(new Student()
                    {
                        Jmbag = Guid.NewGuid().ToString(),
                        Name = name,
                        Mentor = (rand.Next() % 2 ==  0) ? Professors[0] : Professors[1]
                    }
                );
            }
        }
        
    }
}
