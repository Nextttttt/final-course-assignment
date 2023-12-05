using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using FinalCourseAssignment.Data.Entities;
namespace FinalCourseAssignment.Data.Entities
{
    public class Discussion : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string DiscussionText { get; set; }
        public List<Comment> Comments { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}