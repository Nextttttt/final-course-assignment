using System;
using System.Collections.Generic;

namespace FinalCourseAssignment.Api.ViewModels
{
    public class DiscussionWithCommentsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DiscussionText { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
