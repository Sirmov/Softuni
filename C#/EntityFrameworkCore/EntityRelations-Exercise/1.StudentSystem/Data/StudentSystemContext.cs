using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }

        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=StudentSystem;User Id=username;Password=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(e =>
            {
                e.HasKey(sc => new { sc.StudentId, sc.CourseId });

                e.HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

                e.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId);
            });

            modelBuilder.Entity<Homework>(e =>
            {
                e.HasKey(hs => new { hs.StudentId, hs.CourseId });

                e.HasOne(hs => hs.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(hs => hs.StudentId);

                e.HasOne(hs => hs.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(hs => hs.CourseId);

                e.Property(hs => hs.Content)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(e =>
            {
                e.Property(s => s.PhoneNumber)
                .IsUnicode(false);
            });
        }
    }
}
