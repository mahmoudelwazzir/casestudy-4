using casestudy_4.Data;
using casestudy_4.Models;
using casestudy_4.Repo.Implementation;
using Microsoft.EntityFrameworkCore;

namespace casestudy_4.Repo.Reposatory
{
    public class StudentRepo : GenaricRepo<Student>, IStudentRepo
    {
        public StudentRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Student>> FilterByGenderAsync(string gender)
        {
            return await _context.Students.Where(s => s.Gender == gender).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentByNameAsync(string name)
        {
            return await _context.Students.Where(s => s.FullName.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _context.Students.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
