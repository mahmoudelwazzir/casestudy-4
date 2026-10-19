using Microsoft.EntityFrameworkCore;
using casestudy_4.Models;

namespace casestudy_4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==========================================
            // Fluent API Configurations
            // ==========================================

            // 1. One-to-One: Student <-> StudentProfile
            modelBuilder.Entity<Student>()
                .HasOne(s => s.StudentProfile)
                .WithOne(sp => sp.Student)
                .HasForeignKey<StudentProfile>(sp => sp.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentProfile>()
                .HasIndex(sp => sp.StudentId)
                .IsUnique();

            // Unique email constraints
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Teacher>()
                .HasIndex(t => t.Email)
                .IsUnique();

            // 2. One-to-Many: Teacher <-> Course
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. Many-to-Many: Student <-> Course through Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique composite index on Enrollment(StudentId, CourseId)
            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.CourseId })
                .IsUnique();

            // Decimal configuration for Grade
            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Grade)
                .HasPrecision(5, 2);

            // ==========================================
            // Data Seeding (3 records per table)
            // ==========================================

            // 1. Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FullName = "Ali Hassan",
                    Email = "ali.hassan@school.com",
                    Phone = "01011111111",
                    BirthDate = new DateTime(2010, 5, 12),
                    Gender = "Male"
                },
                new Student
                {
                    Id = 2,
                    FullName = "Mariam Ahmed",
                    Email = "mariam.ahmed@school.com",
                    Phone = "01022222222",
                    BirthDate = new DateTime(2010, 8, 20),
                    Gender = "Female"
                },
                new Student
                {
                    Id = 3,
                    FullName = "Omar Khaled",
                    Email = "omar.khaled@school.com",
                    Phone = "01033333333",
                    BirthDate = new DateTime(2009, 11, 5),
                    Gender = "Male"
                }
            );

            // 2. Seed StudentProfiles
            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile
                {
                    Id = 1,
                    Address = "Nasr City, Cairo",
                    ParentPhone = "01111111111",
                    EmergencyContact = "01211111111",
                    StudentId = 1
                },
                new StudentProfile
                {
                    Id = 2,
                    Address = "Heliopolis, Cairo",
                    ParentPhone = "01122222222",
                    EmergencyContact = "01222222222",
                    StudentId = 2
                },
                new StudentProfile
                {
                    Id = 3,
                    Address = "Maadi, Cairo",
                    ParentPhone = "01133333333",
                    EmergencyContact = "01233333333",
                    StudentId = 3
                }
            );

            // 3. Seed Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    FullName = "Ahmed Samir",
                    Email = "ahmed.samir@school.com",
                    Phone = "01044444444",
                    HireDate = new DateTime(2020, 9, 1)
                },
                new Teacher
                {
                    Id = 2,
                    FullName = "Nour Adel",
                    Email = "nour.adel@school.com",
                    Phone = "01055555555",
                    HireDate = new DateTime(2021, 2, 15)
                },
                new Teacher
                {
                    Id = 3,
                    FullName = "Hany Mostafa",
                    Email = "hany.mostafa@school.com",
                    Phone = "01066666666",
                    HireDate = new DateTime(2019, 8, 20)
                }
            );

            // 4. Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Title = "Programming Fundamentals",
                    CreditHours = 3,
                    TeacherId = 1
                },
                new Course
                {
                    Id = 2,
                    Title = "Database Systems",
                    CreditHours = 4,
                    TeacherId = 2
                },
                new Course
                {
                    Id = 3,
                    Title = "Web Development",
                    CreditHours = 3,
                    TeacherId = 1
                }
            );

            // 5. Seed Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = 1,
                    StudentId = 1,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2026, 9, 1),
                    Grade = 90.00m
                },
                new Enrollment
                {
                    Id = 2,
                    StudentId = 2,
                    CourseId = 2,
                    EnrollmentDate = new DateTime(2026, 9, 2),
                    Grade = 85.50m
                },
                new Enrollment
                {
                    Id = 3,
                    StudentId = 3,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2026, 9, 3),
                    Grade = null
                }
            );
        }
    }
}

