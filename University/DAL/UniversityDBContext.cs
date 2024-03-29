﻿using Microsoft.EntityFrameworkCore;
using University.DAL.DTO;

namespace University.DAL
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .HasOne<Course>(s => s.Course)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Student>().ToTable("Students");

            modelBuilder.Entity<Course>().HasData(
            new Course[]
            {
                new Course { Id=1, Name="Радиофизика"},
                new Course { Id=2, Name="Микроэлектроника"},
                new Course { Id=3, Name="Общая физика"}
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Models.StudentModel> StudentModel { get; set; }
        public DbSet<Models.CourseModel> CourseModel { get; set; }
    }
}
