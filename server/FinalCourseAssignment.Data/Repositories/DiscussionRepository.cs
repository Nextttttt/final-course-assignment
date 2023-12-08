using AutoMapper;
using FinalCourseAssignment.Data.Entities;
using FinalCourseAssignment.Domain;
using FinalCourseAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Data.Repositories
{
    public class DiscussionRepository : BaseRepository<DiscussionDto, Discussion> ,IDiscussionRepository
    {
        public DiscussionRepository(ApplicationDbContext dbContext, IMapper mapper)
        :base(dbContext,mapper)
        {
            
        }

        public override async Task<Guid> Create(DiscussionDto dto)
        {
            Discussion newDisc = _mapper.Map<Discussion>(dto);

            entities.Add(newDisc);
            await _dbContext.SaveChangesAsync();

            return newDisc.Id;
        }
        public override async Task<List<DiscussionDto>> GetAll()
        {
            return _mapper.Map<List<DiscussionDto>>(await entities.Include(d => d.Comments).Include(e => e.User).ToListAsync());
        }
        public async Task<List<DiscussionDto>> GetAllByUserId(Guid id)
        {
            return _mapper.Map<List<DiscussionDto>>(await entities.Where(e => e.UserId == id).Include(d => d.Comments).Include(e => e.User).ToListAsync());
        }

        public async Task<List<DiscussionDto>> GetTopFiveDiscussions()
        {
            return _mapper.Map<List<DiscussionDto>>(await entities.OrderByDescending(e => e.Comments.Count).Take(5).ToListAsync());
        }
    }
}