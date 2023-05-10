using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Exercise.Data.Repositories;
using Exercise.Data.Models;
using Exercise.Domain.Interfaces;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly ICoursesService _coursesServices;

        public CoursesController(ICoursesRepository coursesRepository,
                                 ICoursesService coursesServices)
        {
            _coursesRepository = coursesRepository;
            _coursesServices = coursesServices;
        }

        // GET: api/<CoursesController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return MapResponse(_coursesRepository.GetAll());
        }

        // GET api/<CoursesController>/size/5/offset/10
        [HttpGet("size/{size}/offset/{offset}")]
        public IEnumerable<Course> Get(int size, int offset)
        {
            return MapResponse(_coursesRepository.GetMany(size, offset));
        }

        // GET api/<CoursesController>/5
        [HttpGet("{courseId}")]
        public Course Get(int courseId)
        {
            return ParseDTO(_coursesRepository.Get(courseId));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public void Post([FromBody] Course course)
        {
            _coursesServices.Create(ToDTO(course));
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{courseId}")]
        public void Put(int courseId, [FromBody] Course course)
        {
            _coursesServices.Update(courseId, ToDTO(course));
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{courseId}")]
        public void Delete(int courseId)
        {
            _coursesServices.Delete(courseId);
        }

        private IEnumerable<Course> MapResponse(IEnumerable<CourseDTO> dtos)
        {
            List<Course> courses = new List<Course>();
            foreach (var dto in dtos)
            {
                courses.Add(ParseDTO(dto));
            }
            return courses;
        }

        private Course ParseDTO(CourseDTO courseDto) => new Course
        {
            CourseId = courseDto.CourseId,
            Title = courseDto.Title,
            Description = courseDto.Description
        };

        private CourseDTO ToDTO(Course course) => new CourseDTO
        {
            CourseId = course.CourseId,
            Title = course.Title,
            Description = course.Description
        };

    }
}
