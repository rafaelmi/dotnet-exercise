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
        public async Task<IEnumerable<CourseDTO>> Get()
        {
            return await _coursesRepository.GetAll();
        }

        // GET api/<CoursesController>/size/5/offset/10
        [HttpGet("size/{size}/offset/{offset}")]
        public async Task<IEnumerable<CourseDTO>> Get(int size, int offset)
        {
            return await _coursesRepository.GetMany(size, offset);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{courseId}")]
        public async Task<CourseDTO> Get(int courseId)
        {
            return await _coursesRepository.Get(courseId);
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task Post([FromBody] CourseDTO course)
        {
            await _coursesServices.Create(course);
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{courseId}")]
        public async Task Put(int courseId, [FromBody] CourseDTO course)
        {
            await _coursesServices.Update(courseId, course);
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{courseId}")]
        public async Task Delete(int courseId)
        {
            await _coursesServices.Delete(courseId);
        }
    }
}
