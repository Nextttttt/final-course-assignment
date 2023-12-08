using AutoMapper;
using FinalCourseAssignment.Domain.Models;
using FinalCourseAssignment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Data.Repositories
{
    public class CommentRepository : BaseRepository<CommentDto,Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext dbContext, IMapper mapper)
        : base(dbContext, mapper)
        {

        }

        public async Task<List<CommentDto>> GetAllByDiscussionId(Guid id)
        {
            return _mapper.Map<List<CommentDto>>(await entities.Where(e => e.DiscussionId == id).ToListAsync());
        }
    }
}