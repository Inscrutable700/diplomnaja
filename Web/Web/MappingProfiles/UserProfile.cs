using AutoMapper;
using Data.Models;
using Web.ViewModels;

namespace Web.MappingProfiles
{
    public class UserProfile : ProfileBase
    {
        protected override void Configure()
        {
            Mapper.CreateMap<UserTest, UserTestViewModel>()
                .ForMember(dest => dest.ID, ost => ost.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, ost => ost.MapFrom(src => src.Test.Name))
                .ForMember(dest => dest.Description, ost => ost.MapFrom(src => src.Test.Description))
                .ForMember(dest => dest.DateStart, ost => ost.MapFrom(src => src.GroupToTest.DateStart == null ? null : src.GroupToTest.DateStart.ToString()))
                .ForMember(dest => dest.DateEnd, ost => ost.MapFrom(src => src.GroupToTest.DateEnd == null ? null : src.GroupToTest.DateEnd.ToString()))
                .ForMember(dest => dest.IsCompleted, ost => ost.MapFrom(src => src.IsCompleted));
        }
    }
}