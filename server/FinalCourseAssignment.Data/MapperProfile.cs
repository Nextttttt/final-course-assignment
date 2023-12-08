using AutoMapper;
using FinalCourseAssignment.Data.Entities;
using FinalCourseAssignment.Domain.Models;
using System.Collections.Generic;

namespace FinalCourseAssignment.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<DiscussionDto, Discussion>();
            CreateMap<Discussion, DiscussionDto>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(from => from.User.Username))
                .ForMember(x => x.CommentCount, opt => opt.MapFrom(from => from.Comments.Count));
            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(from => from.User.Username));
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
