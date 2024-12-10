using AutoMapper;
using SurveyForm.Data;
using SurveyForm.ViewModels;

namespace SurveyForm.Utility;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)).ReverseMap();
        CreateMap<ApplicationUser, UserProfileViewModel>().ReverseMap();
        CreateMap<Answer, AnswerViewModel>().ReverseMap();
        CreateMap<Comment, CommentViewModel>().ReverseMap();
        CreateMap<Form, FormViewModel>().ReverseMap();
        CreateMap<Like, LikeViewModel>().ReverseMap();
        CreateMap<Question, QuestionViewModel>().ReverseMap();
        CreateMap<QuestionOption, QuestionOptionViewModel>().ReverseMap();
        CreateMap<Tag, TagViewModel>().ReverseMap();
        CreateMap<Template, TemplateViewModel>().ReverseMap();
        CreateMap<TemplateSpecificUser, TemplateSpecificUserViewModel>().ReverseMap();
        CreateMap<Topic, TopicViewModel>().ReverseMap();

        CreateMap<FormViewModel, TemplateViewModel>().ReverseMap();
    }
}
