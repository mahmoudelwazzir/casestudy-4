using casestudy_4.Models;

namespace casestudy_4.Repo.Implementation
{
    public interface ICourseRepo : IGenaricRepo<Course>
    {
        Task<IEnumerable<Course>> GetCourseByTitelAsync(string title);
        Task<IEnumerable<Course>> FilterCourse(int CreditHours);
    }
}
