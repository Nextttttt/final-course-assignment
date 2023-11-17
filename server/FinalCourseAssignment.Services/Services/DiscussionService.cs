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
        public DiscussionService(IDiscussionRepository discussionRepository)
        :base(discussionRepository)
        {
            
        }
    }
}