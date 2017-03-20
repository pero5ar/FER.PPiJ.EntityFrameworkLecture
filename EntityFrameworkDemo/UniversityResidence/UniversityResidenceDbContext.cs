using System.Data.Entity;
using UniversityResidence.Models;

namespace UniversityResidence
{
    public class UniversityResidenceDbContext : DbContext
    {
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<ResidenceHall> Halls { get; set; }
        public IDbSet<Room> Rooms { get; set; }
        public IDbSet<Student> Students { get; set; }

        public UniversityResidenceDbContext(string connectionString) : base(connectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasOptional(s => s.Room).WithMany(r => r.Occupants);
            modelBuilder.Entity<Room>().HasRequired(r => r.Hall).WithMany(h => h.Rooms);
            modelBuilder.Entity<Employee>().HasMany(e => e.WorkPlace).WithMany(h => h.Employees);
        }
    }
}
