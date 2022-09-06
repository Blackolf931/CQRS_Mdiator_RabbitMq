using AutoMapper;
using BLL.Models;
using CQRS_Mediator.ViewModels.Office;

namespace CQRS_Mediator.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OfficeViewModel, Office>().ReverseMap();
        }
    }
}
