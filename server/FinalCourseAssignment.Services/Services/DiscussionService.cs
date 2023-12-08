using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalCourseAssignment.Domain;
using FinalCourseAssignment.Domain.Models;
using FinalCourseAssignment.Domain.Services;

namespace FinalCourseAssignment.Services.Services
{
    public class DiscussionService : BaseService<DiscussionDto>, IDiscussionService
    {
        private readonly IDiscussionRepository _discussionRepository;
        public DiscussionService(IDiscussionRepository discussionRepository)
        :base(discussionRepository)
        {
            _discussionRepository = discussionRepository;
        }

        public async Task<List<DiscussionDto>> GetAllByUserId(Guid id)
        {
            return await _discussionRepository.GetAllByUserId(id);
        }

        public async Task<List<DiscussionDto>> GetTopFiveDiscussions()
        {
            return await _discussionRepository.GetTopFiveDiscussions();
        }
    }
}