using AutoMapper;
using FinalCourseAssignment.Data.Entities;
using FinalCourseAssignment.Domain;
using FinalCourseAssignment.Domain.Models;
using System;
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
    }
}