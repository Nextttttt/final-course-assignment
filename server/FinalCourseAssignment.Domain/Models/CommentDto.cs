using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Domain.Models
{
    public class CommentDto : BaseModel
    {
        public string Text { get; set; }

        public Guid DiscussionId { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}