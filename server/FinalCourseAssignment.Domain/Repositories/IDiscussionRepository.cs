using FinalCourseAssignment.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace FinalCourseAssignment.Domain
{
    public interface IDiscussionRepository : IBaseRepository<DiscussionDto>
    {
        public Task<List<DiscussionDto>> GetAllByUserId(Guid id);
        public Task<List<DiscussionDto>> GetTopFiveDiscussions();

    }
}