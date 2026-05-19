using AutoMapper;
using Lap02.DTOs.Department;
using Lap02.DTOs.Student;
using Lap02.Models;

namespace Lap02.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentReadDto>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.SupervisorName, opt => opt.MapFrom(src => src.Supervisor != null ? src.Supervisor.Name : null));

        CreateMap<StudentCreateDto, Student>();

        CreateMap<StudentUpdateDto, Student>();

        CreateMap<Department, DepartmentReadDto>();

        CreateMap<DepartmentCreateDto, Department>();

        CreateMap<DepartmentUpdateDto, Department>();
    }
}
