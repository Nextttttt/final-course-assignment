namespace FinalCourseAssignment.Domain
{
    public interface IBaseService
    {
        public bool Create();

        public BaseModel GetById(Guid id);

        public bool UpdateById(Guid id);

        public bool DeleteById(GUid id);
    }
}