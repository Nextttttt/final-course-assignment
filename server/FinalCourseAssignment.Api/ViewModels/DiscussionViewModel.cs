using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Api.ViewModels
{
    public class DiscussionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DiscussionText { get; set; }
        public Guid UserId { get; set; }
    }
}