using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FinalCourseAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalCourseAssignment.Data
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Salt { get; set; }
        public List<Discussion> Discussions { get; set; }
        public List<Comment> Comments { get; set; }
    }
}