using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
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
            Print();
            DeleteDemo();
            Print();
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
