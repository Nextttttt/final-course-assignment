using System;
using System.ComponentModel.DataAnnotations;
using FinalCourseAssignment.Data.Entities;

namespace FinalCourseAssignment.Data
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid? DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
        [Required]
        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}