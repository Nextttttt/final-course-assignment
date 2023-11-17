using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using FinalCourseAssignment.Data.Entities;
namespace FinalCourseAssignment.Data
{
    public class Discussion : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string DiscussionText { get; set; }
        public List<Comment> Comments { get; set; }
        [Required]
        public User UserCreater { get; set; }
    }
}