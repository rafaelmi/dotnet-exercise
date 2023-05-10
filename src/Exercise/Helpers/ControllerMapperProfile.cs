using AutoMapper;
using Exercise.Data.DTOs;
using Exercise.Models;

namespace Exercise.Helpers
{
    public class ControllerMapperProfile : Profile
    {
        public ControllerMapperProfile() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Course,  CourseDTO>();
            CreateMap<CourseDTO, Course>();
        }
    }
}
