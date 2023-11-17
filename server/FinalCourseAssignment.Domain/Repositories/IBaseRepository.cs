using System;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Domain
{
    public interface IBaseRepository<TDto>
    where TDto : BaseModel
    {
        public Task<bool> Create(TDto dto);

        public Task<TDto> GetById(Guid id);

        public Task<bool> Update(TDto dto);

        public Task<bool> DeleteById(Guid id);
    }
}