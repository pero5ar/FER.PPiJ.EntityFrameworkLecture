using System.Data.Entity;
using SimpleUniversityManagement.Models;

namespace SimpleUniversityManagement
{
    public class UniversityDbContext : DbContext
    {
        // tables
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Professor> Professors { get; set; }
        public IDbSet<Class> Classes { get; set; }

        public UniversityDbContext(string connectionString) : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set primary keys
            // modelBuilder.Entity<Student>().HasKey(student => student.Jmbag); // already set via data annotations
            modelBuilder.Entity<Professor>().HasKey(professor => professor.Id);
            modelBuilder.Entity<Class>().HasKey(c => c.Id); // "class" is not the best name

            // set relations
            modelBuilder.Entity<Student>().HasOptional(s => s.Mentor).WithMany(p => p.MentoredStudents);
            modelBuilder.Entity<Student>().HasMany(s => s.EnrolledClasses).WithMany(c => c.EnrolledStudents);
            modelBuilder.Entity<Professor>().HasMany(p => p.ClassesTeaching).WithMany(c => c.Professors);
            
            // set Professor properties
            modelBuilder.Entity<Professor>().Property(p => p.Name).HasMaxLength(30);
            modelBuilder.Entity<Professor>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Professor>().Property(p => p.Name).HasColumnName("ProfessorName");
        }


    }
}
