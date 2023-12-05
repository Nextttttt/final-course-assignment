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
            CreateMap<DiscussionDto, Discussion>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
