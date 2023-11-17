namespace FinalCourseAssignment.Domain
{
    public interface IBaseRepository
    {
        public bool Create();

        public BaseModel GetById(Guid id);

        public bool UpdateById(Guid id);

        public bool DeleteById(Guid id);

        private bool Save(User user);
    }
}