using AutoMapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.MappingProfiles
{
    public class TestProfile : ProfileBase
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Test, TestViewModel>();
            Mapper.CreateMap<TestViewModel, Test>();
            Mapper.CreateMap<Test, SelectListItem>()
                .ForMember(dest => dest.Text, ost => ost.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, ost => ost.MapFrom(src => src.ID.ToString()));
        }
    }
}