using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalCourseAssignment.Domain.Models;

namespace FinalCourseAssignment.Domain.Services
{
    public interface IDiscussionService : IBaseService<DiscussionDto>
    {
        public Task<List<DiscussionDto>> GetAllByUserId(Guid id);
        public Task<List<DiscussionDto>> GetTopFiveDiscussions();

    }
}