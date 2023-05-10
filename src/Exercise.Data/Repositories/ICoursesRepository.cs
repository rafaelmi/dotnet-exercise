using Exercise.Data.DTOs;

namespace Exercise.Data.Repositories
{
    public interface ICoursesRepository
    {
        CourseDTO Get(int courseId);
        IEnumerable<CourseDTO> GetAll();
        IEnumerable<CourseDTO> GetMany(int size, int offset);
        int Create(CourseDTO course);
        int Update(int courseId, CourseDTO course);
        int Delete(int courseId);
    }
}
