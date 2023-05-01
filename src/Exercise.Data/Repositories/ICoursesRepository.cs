using Exercise.Data.Models;

namespace Exercise.Data.Repositories
{
    public interface ICoursesRepository
    {
        Task<CourseDTO> Get(int courseId);
        Task<IEnumerable<CourseDTO>> GetAll();
        Task<IEnumerable<CourseDTO>> GetMany(int size, int offset);
        Task<int> Create(CourseDTO course);
        Task<int> Update(int courseId, CourseDTO course);
        Task<int> Delete(int courseId);
    }
}
