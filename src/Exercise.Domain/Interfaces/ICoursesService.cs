using Exercise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain.Interfaces
{
    public interface ICoursesService
    {
        Task<bool> Create(CourseDTO course);
        Task<bool> Update(int courseId, CourseDTO course);
        Task<bool> Delete(int courseId);
    }
}
