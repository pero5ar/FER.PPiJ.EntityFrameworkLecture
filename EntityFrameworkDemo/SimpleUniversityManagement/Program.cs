using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SimpleUniversityManagement.Models;

namespace SimpleUniversityManagement
{
    class Program
    {
        private const string ConnectionString = "SimpleUniversityDatabase";

        static void Main(string[] args)
        {
            CreateDemo();
            // Print().Wait();
            RunDemo();
            DeleteDemo();
            // Print().Wait();
        }

        private static void RunDemo()
        {
            using (var db = new UniversityDbContext(ConnectionString)) // write your code in this block
            {
                var stud = new Student()
                {
                    Jmbag = "0036123456",
                    Name = "Pero"
                };
                var prof = new Professor()
                {
                    Name = "Ivan"
                };
                stud.Mentor = prof;

                db.Students.Add(stud);
                db.Professors.Add(prof);
                db.SaveChanges();
                Console.WriteLine(db.Students.Find(stud.Jmbag)?.Name);

                var s = db.Students.Find(stud.Jmbag);
                s.Name = "Petar";
                db.Entry(s).State = EntityState.Modified;
                db.SaveChanges();
                Console.WriteLine(db.Students.Find(stud.Jmbag)?.Name);

                var p1 = db.Professors.Where(p => p.Name.StartsWith("I")).Select(p => "Id: " + p.Id);
                Console.WriteLine(p1.FirstOrDefault());
                var p2 = from p in db.Professors
                    where p.Name.StartsWith("I")
                    select "Id: " + p.Id;
                Console.WriteLine(p2.FirstOrDefault());
                

                db.Students.Remove(stud);
                db.SaveChanges();
                Console.WriteLine(db.Students.Find(stud.Jmbag)?.Name);
                Console.WriteLine(db.Professors.Find(prof.Id)?.Name);
            }
        }

        private static void CreateDemo()
        {
            using (var db = new UniversityDbContext(ConnectionString))
            {
                var data = new TestData(new Random());
                data.Professors.ForEach(p => db.Professors.Add(p));
                data.Students.ForEach(s => db.Students.Add(s));
                db.SaveChanges();
            }
        }

        private static async Task Print()
        {
            using (var db = new UniversityDbContext(ConnectionString))
            {
                await db.Students.ForEachAsync(s => Console.WriteLine($"{s.Jmbag} {s.Name}"));
                await db.Professors.ForEachAsync(p => Console.WriteLine($"{p.Id} {p.Name}"));
                await db.Classes.ForEachAsync(c => Console.WriteLine($"{c.Id} {c.Ects} {c.Name}"));
            }
            Console.WriteLine("END PRINT");
        }

        private static void DeleteDemo()
        {
            using (var db = new UniversityDbContext(ConnectionString))
            {
                var profs = db.Professors.ToList();
                profs.ForEach(p => db.Professors.Remove(p));
                var studs = db.Students.ToList();
                studs.ForEach(s => db.Students.Remove(s));
                var cs = db.Classes.ToList();
                cs.ForEach(c => db.Classes.Remove(c));
                db.SaveChanges();
            }
            Console.WriteLine("IZBRISANO");
        }


    }
}
