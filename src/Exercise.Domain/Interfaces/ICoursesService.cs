using Exercise.Data.DTOs;

namespace Exercise.Domain.Interfaces
{
    public interface ICoursesService
    {
        void Create(CourseDTO course);
        void Update(int courseId, CourseDTO course);
        void Delete(int courseId);
    }
}
