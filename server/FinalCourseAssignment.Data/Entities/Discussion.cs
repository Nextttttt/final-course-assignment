using System.Collections.Generic;
using System.Security.AccessControl;
namespace FinalCourseAssignment.Data
{
    public class Discussion : BaseModel
    {
        public string Title { get; set; }
        public string Discussion { get; set; }
        public List<Comment> Comments { get; set; }
        public User UserCreater { get; set; }
    }
}