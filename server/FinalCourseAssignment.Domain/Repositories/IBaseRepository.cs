using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Domain
{
    public interface IBaseRepository<TDto>
    where TDto : BaseModel
    {
        public Task<Guid> Create(TDto dto);

        public Task<TDto> GetById(Guid id);

        public Task<bool> Update(TDto dto);

        public Task<bool> DeleteById(Guid id);

        public Task<List<TDto>> GetAll();
    }
}