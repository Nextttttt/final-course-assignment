using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalCourseAssignment.Domain;
using FinalCourseAssignment.Domain.Services;

namespace FinalCourseAssignment.Services.Services
{
    public class BaseService<TDto> : IBaseService<TDto>
    where TDto : BaseModel
    {
        protected readonly IBaseRepository<TDto> _baseRepository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        virtual public async Task<Guid> Create(TDto dto)
        {
           return await _baseRepository.Create(dto);
        }

        public async Task<TDto> GetById(Guid id)
        {
            return await _baseRepository.GetById(id);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            return await _baseRepository.DeleteById(id);
        }

        public async Task<bool> Update(TDto dto)
        {
            return await _baseRepository.Update(dto);
        }

        public async Task<List<TDto>> GetAll()
        {
            return await _baseRepository.GetAll();
        }
    }
}