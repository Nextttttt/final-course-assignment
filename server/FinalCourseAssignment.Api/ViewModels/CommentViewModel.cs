using System;

namespace FinalCourseAssignment.Api.ViewModels
{
    public class CommentViewModel
    {
        public string Text { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }
    }
}
