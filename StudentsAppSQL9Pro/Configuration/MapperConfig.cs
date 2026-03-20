using AutoMapper;
using StudentsAppSQL9Pro.DTO;
using StudentsAppSQL9Pro.Models;

namespace StudentsAppSQL9Pro.Configuration
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<StudentInsertDTO, Student>().ReverseMap();
            CreateMap<StudentUpdateDTO, Student>().ReverseMap();
            CreateMap<StudentReadOnlyDTO, Student>().ReverseMap();
        }
    }
}
