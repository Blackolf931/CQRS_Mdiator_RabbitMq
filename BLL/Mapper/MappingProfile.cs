using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeEntity, Employee>().ReverseMap();
            CreateMap<OfficeEntity, Office>().ReverseMap();
        }
    }
}
