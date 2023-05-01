using Exercise.Data.Models;

namespace Exercise.Domain.Interfaces
{
    public interface ICoursesService
    {
        Task<bool> Create(CourseDTO course);
        Task<bool> Update(int courseId, CourseDTO course);
        Task<bool> Delete(int courseId);
    }
}
