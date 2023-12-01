using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Domain.Models
{
    public class CommentDto : BaseModel
    {
        public string Text { get; set; }

        public Guid CreaterId { get; set; } 
    }
}