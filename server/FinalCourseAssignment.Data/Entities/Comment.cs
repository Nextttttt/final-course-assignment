using System.ComponentModel.DataAnnotations;
using FinalCourseAssignment.Data.Entities;

namespace FinalCourseAssignment.Data
{
    public class Comment : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        public Discussion Discussion { get; set; }
        public User UserCreater { get; set; }
    }
}