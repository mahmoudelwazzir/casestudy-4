using casestudy_4.Data;
using casestudy_4.Models;
using casestudy_4.Repo.Reposatory;

namespace casestudy_4.Repo.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IStudentRepo students, IGenaricRepo<StudentProfile> studentProfiles, ICourseRepo courses, IGenaricRepo<Teacher> teachers, IGenaricRepo<Enrollment> enrollments)
        {
            _context = context;
            Students = students;
            StudentProfiles = studentProfiles;
            Courses = courses;
            Teachers = teachers;
            Enrollments = enrollments;
        }

        public IStudentRepo Students { get; }

        public IGenaricRepo<StudentProfile> StudentProfiles { get; }

        public ICourseRepo Courses { get; }

        public IGenaricRepo<Teacher> Teachers { get; }

        public IGenaricRepo<Enrollment> Enrollments { get; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
