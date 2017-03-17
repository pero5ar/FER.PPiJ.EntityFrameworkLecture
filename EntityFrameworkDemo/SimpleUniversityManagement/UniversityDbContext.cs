﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            modelBuilder.Entity<Student>().HasKey(student => student.Jmbag);
            modelBuilder.Entity<Professor>().HasKey(professor => professor.Id);
            modelBuilder.Entity<Class>().HasKey(c => c.Id); // "class" is not the best name

            // set relations
            modelBuilder.Entity<Student>().HasOptional(s => s.Mentor).WithMany(p => p.MentoredStudents);
            modelBuilder.Entity<Student>().HasMany(s => s.EnrolledClasses).WithMany(c => c.EnrolledStudents);
            modelBuilder.Entity<Professor>().HasMany(p => p.ClassesTeaching).WithMany(c => c.Professors);

        }


    }
}
