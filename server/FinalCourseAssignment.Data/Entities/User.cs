using System.Collections.Generic;
using FinalCourseAssignment.Data.Entities;

namespace FinalCourseAssignment.Data
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Discussion> Discussions { get; set; }
        public List<Comment> Comments { get; set; }
    }
}