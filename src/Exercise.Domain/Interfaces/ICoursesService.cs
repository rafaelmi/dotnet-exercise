using Exercise.Data.DTOs;

namespace Exercise.Domain.Interfaces
{
    public interface ICoursesService
    {
        bool Create(CourseDTO course);
        bool Update(int courseId, CourseDTO course);
        bool Delete(int courseId);
    }
}
