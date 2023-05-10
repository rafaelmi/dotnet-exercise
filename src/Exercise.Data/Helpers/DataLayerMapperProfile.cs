using AutoMapper;
using Exercise.Data.Models;

namespace Exercise.Data.Helpers
{
    public class DataLayerMapperProfile : Profile
    {
        public DataLayerMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Course, CourseDTO>();
            CreateMap<CourseDTO, Course>();
        }
    }
}
