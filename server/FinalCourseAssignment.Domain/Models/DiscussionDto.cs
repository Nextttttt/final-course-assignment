using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Domain.Models
{
    public class DiscussionDto : BaseModel
    {
        public string Title { get; set; }
        public string DiscussionText { get; set; }
        public List<CommentDto> Comments { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int CommentCount { get; set; }
    }
}