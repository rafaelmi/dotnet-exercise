using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Exercise.Models;
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
        public async Task<IEnumerable<Course>> Get()
        {
            return MapResponse(await _coursesRepository.GetAll());
        }

        // GET api/<CoursesController>/size/5/offset/10
        [HttpGet("size/{size}/offset/{offset}")]
        public async Task<IEnumerable<Course>> Get(int size, int offset)
        {
            return MapResponse(await _coursesRepository.GetMany(size, offset));
        }

        // GET api/<CoursesController>/5
        [HttpGet("{courseId}")]
        public async Task<Course> Get(int courseId)
        {
            return ParseDTO(await _coursesRepository.Get(courseId));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task Post([FromBody] Course course)
        {
            await _coursesServices.Create(ToDTO(course));
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{courseId}")]
        public async Task Put(int courseId, [FromBody] Course course)
        {
            await _coursesServices.Update(courseId, ToDTO(course));
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{courseId}")]
        public async Task Delete(int courseId)
        {
            await _coursesServices.Delete(courseId);
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
