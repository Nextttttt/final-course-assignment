using AutoMapper;
using FinalCourseAssignment.Data.Entities;
using FinalCourseAssignment.Domain;
using FinalCourseAssignment.Domain.Models;

namespace FinalCourseAssignment.Data.Repositories
{
    public class DiscussionRepository : BaseRepository<DiscussionDto, Discussion> ,IDiscussionRepository
    {
        public DiscussionRepository(ApplicationDbContext dbContext, IMapper mapper)
        :base(dbContext,mapper)
        {
            
        }
    }
}