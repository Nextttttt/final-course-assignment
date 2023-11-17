namespace FinalCourseAssignment.Data
{
    public class Comment : BaseModel
    {
        public string Text { get; set; }
        public User UserCreater { get; set; }
    }
}