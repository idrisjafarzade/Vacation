using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, LoginDto>().ReverseMap();
            CreateMap<VacationApply, VacationApplyDto>().ReverseMap();
        }
    }
}
