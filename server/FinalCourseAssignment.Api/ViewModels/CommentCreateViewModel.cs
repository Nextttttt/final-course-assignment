using System;

namespace FinalCourseAssignment.Api.ViewModels
{
    public class CommentCreateViewModel
    {
        public string Text { get; set; }

        public Guid DiscussionId { get; set; }
    }
}
