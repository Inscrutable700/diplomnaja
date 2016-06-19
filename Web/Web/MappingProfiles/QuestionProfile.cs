using AutoMapper;
using Data.Models;
using Web.ViewModels;

namespace Web.MappingProfiles
{
    public class QuestionProfile : ProfileBase
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AvailableAnswerViewModel, AvailableAnswer>();
            Mapper.CreateMap<AvailableAnswer, AvailableAnswerViewModel>();
            Mapper.CreateMap<QuestionViewModel, Question>();
            Mapper.CreateMap<Question, QuestionViewModel>()
                .ForMember(dest => dest.AvailableAnswers, ost => ost.MapFrom(src => Mapper.Map<AvailableAnswerViewModel[]>(src.AwailableAnswers)));
        }
    }
}