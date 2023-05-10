using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Exercise.Data.Repositories;
using Exercise.Data.Models;
using Exercise.Domain.Interfaces;
using Exercise.Data.DTOs;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepository;
        private readonly ICoursesService _coursesServices;

        public CoursesController(IMapper mapper,
            ICoursesRepository coursesRepository,
            ICoursesService coursesServices)
        {
            _mapper = mapper;
            _coursesRepository = coursesRepository;
            _coursesServices = coursesServices;
        }

        // GET: api/<CoursesController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _mapper.Map<IEnumerable<Course>>(_coursesRepository.GetAll());
        }

        // GET api/<CoursesController>/size/5/offset/10
        [HttpGet("size/{size}/offset/{offset}")]
        public IEnumerable<Course> Get(int size, int offset)
        {
            return _mapper.Map<IEnumerable<Course>>(_coursesRepository.GetMany(size, offset));
        }

        // GET api/<CoursesController>/5
        [HttpGet("{courseId}")]
        public Course Get(int courseId)
        {
            return _mapper.Map<Course>(_coursesRepository.Get(courseId));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public void Post([FromBody] Course course)
        {
            _coursesServices.Create(_mapper.Map<CourseDTO>(course));
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{courseId}")]
        public void Put(int courseId, [FromBody] Course course)
        {
            _coursesServices.Update(courseId, _mapper.Map<CourseDTO>(course));
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{courseId}")]
        public void Delete(int courseId)
        {
            _coursesServices.Delete(courseId);
        }
    }
}
