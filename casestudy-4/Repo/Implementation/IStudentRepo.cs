using casestudy_4.Models;

namespace casestudy_4.Repo.Implementation
{
    public interface IStudentRepo : IGenaricRepo<Student>
    {
        Task<IEnumerable<Student>> GetStudentByNameAsync(string name);
        Task<IEnumerable<Student>> FilterByGenderAsync(string gender);
        Task<IEnumerable<Student>> GetStudentsWithPaginationAsync(int pageNumber, int pageSize);
    }
}
