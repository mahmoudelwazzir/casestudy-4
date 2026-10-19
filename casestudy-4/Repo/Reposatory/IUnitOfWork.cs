using casestudy_4.Models;
using casestudy_4.Repo.Implementation;

namespace casestudy_4.Repo.Reposatory
{
    public interface IUnitOfWork
    {
        public IStudentRepo Students { get; }
        public IGenaricRepo<StudentProfile> StudentProfiles { get; }
        public ICourseRepo Courses { get; }
        public IGenaricRepo<Teacher> Teachers { get; }
        public IGenaricRepo<Enrollment> Enrollments { get; }
        public Task SaveAsync();
    }
}
