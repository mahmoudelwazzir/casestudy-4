using casestudy_4.Data;
using casestudy_4.Models;
using casestudy_4.Repo.Implementation;
using Microsoft.EntityFrameworkCore;

namespace casestudy_4.Repo.Reposatory
{
    public class CourseRepo : GenaricRepo<Course>, ICourseRepo
    {
        public CourseRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Course>> FilterCourse(int CreditHours)
        {
            return await _context.Courses.Where(c => c.CreditHours == CreditHours).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCourseByTitelAsync(string title)
        {
            return await _context.Courses.Where(c => c.Title == title).ToListAsync();
        }
    }
}
