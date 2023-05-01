using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Data.Repositories;
using Exercise.Data.Models;
using Exercise.Domain.Interfaces;

namespace Exercise.Domain.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesService(ICoursesRepository coursesRepository) 
        {
            _coursesRepository = coursesRepository;
        }

        public async Task<bool> Create(CourseDTO course)
        {
            int count = await _coursesRepository.Create(course);
            return count == 1;
        }

        public async Task<bool> Update(int courseId, CourseDTO course)
        {
            int count = await _coursesRepository.Update(courseId, course);
            return count == 1;
        }
        public async Task<bool> Delete(int courseId)
        {
            int count = await _coursesRepository.Delete(courseId);
            return count == 1;
        }
    }
}
