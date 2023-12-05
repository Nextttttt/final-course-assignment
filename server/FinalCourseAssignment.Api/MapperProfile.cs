using AutoMapper;
using FinalCourseAssignment.Api.ViewModels;
using FinalCourseAssignment.Domain.Models;

namespace FinalCourseAssignment.Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<DiscussionDto, DiscussionViewModel>().ReverseMap();
            CreateMap<DiscussionDto, DiscussionUpdateViewModel>().ReverseMap();
            CreateMap<DiscussionDto, DiscussionCreateViewModel>().ReverseMap();

            CreateMap<CommentDto, CommentCreateViewModel>().ReverseMap();
            CreateMap<CommentDto, CommentUpdateViewModel>().ReverseMap();
            CreateMap<CommentDto, CommentViewModel>().ReverseMap();

            CreateMap<UserLoginDto, UserLoginViewModel>().ReverseMap();
            CreateMap<UserDto, UserRegisterViewModel>().ReverseMap();
            CreateMap<UserDto, UserUpdateViewModel>().ReverseMap();
            CreateMap<UserDto, UserViewModel>().ReverseMap();
        }
    }
}
