using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise.Data.Repositories;
using Exercise.Domain.Interfaces;
using Exercise.Data.DTOs;

namespace Exercise.Domain.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesService(ICoursesRepository coursesRepository) 
        {
            _coursesRepository = coursesRepository;
        }

        public bool Create(CourseDTO course)
        {
            int count = _coursesRepository.Create(course);
            return count == 1;
        }

        public bool Update(int courseId, CourseDTO course)
        {
            int count = _coursesRepository.Update(courseId, course);
            return count == 1;
        }
        public bool Delete(int courseId)
        {
            int count = _coursesRepository.Delete(courseId);
            return count == 1;
        }
    }
}
