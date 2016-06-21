using System.Web.Mvc;
using AutoMapper;
using Data.Models;

namespace Web.MappingProfiles
{
    public class GroupProfile : ProfileBase
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Group, SelectListItem>()
                .ForMember(dest => dest.Text, ost => ost.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, ost => ost.MapFrom(src => src.ID.ToString()))
                .ForMember(dest => dest.Group, ost => ost.Ignore());
        }
    }
}