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
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
            :base(commentRepository)
        {
            
        }

        public async Task<List<CommentDto>> GetAllByDiscussionId(Guid id)
        {
            return await _commentRepository.GetAllByDiscussionId(id);
        }
    }
}
