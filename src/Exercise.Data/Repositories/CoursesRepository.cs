﻿using AutoMapper.QueryableExtensions;
using AutoMapper;
using Exercise.Data.Models;
using Exercise.Data.DTOs;

namespace Exercise.Data.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly GlobalDbContext _context;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;

        public CoursesRepository(GlobalDbContext context,
            IConfigurationProvider configurationProvider,
            IMapper mapper)
        {
            _context = context;
            _configurationProvider = configurationProvider;
            _mapper = mapper;
        }

        public CourseDTO Get(int courseId)
        {
            return _mapper.Map<CourseDTO>(GetAsEntity(courseId));
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return _context.Courses
                .ProjectTo<CourseDTO>(_configurationProvider)
                .ToList();
        }

        public IEnumerable<CourseDTO> GetMany(int size, int offset)
        {
            return _context.Courses
                .Skip(offset)
                .Take(size)
                .ProjectTo<CourseDTO>(_configurationProvider)
                .ToList();
        }

        public int Create(CourseDTO courseDto)
        {
            Course course = _mapper.Map<Course>(courseDto);
            _context.Add(course);
            return _context.SaveChanges();
        }

        public int Update(int courseId, CourseDTO courseDto)
        {
            var course = GetAsEntity(courseId);
            course.Title = courseDto.Title;
            course.Description = courseDto.Description;
            return _context.SaveChanges();
        }

        public int Delete(int courseId)
        {
            var course = GetAsEntity(courseId);
            _context.Courses.Remove(course);
            return _context.SaveChanges();
        }

        private Course GetAsEntity (int courseId)
        {
            var course = _context.Courses.Find(courseId);
            if (course == null) throw new KeyNotFoundException();
            return course;
        }
    }
}
