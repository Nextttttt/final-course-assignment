using AutoMapper;
using FinalCourseAssignment.Data;
using FinalCourseAssignment.Domain.Models;
using FinalCourseAssignment.Domain.Repositories;
using FinalCourseAssignment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Services.Services
{
    public class CommentService : BaseService<CommentDto>, ICommentService
    {
        public CommentService(ICommentRepository commentRepository)
            :base(commentRepository)
        {
            
        }
    }
}
