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

        public void Create(CourseDTO course)
        {
            _coursesRepository.Create(course);
        }

        public void Update(int courseId, CourseDTO course)
        {
            _coursesRepository.Update(courseId, course);
        }
        public void Delete(int courseId)
        {
            _coursesRepository.Delete(courseId);
        }
    }
}
