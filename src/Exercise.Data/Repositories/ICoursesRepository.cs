using Exercise.Data.Models;

namespace Exercise.Data.Repositories
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<Course>> GetMany(int size, int offset);
        Task<int> Create(Course course);
        Task<int> Update(Course course);
        Task<int> Delete(int courseId);
    }
}
