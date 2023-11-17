using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalCourseAssignment.Data.Entities;
using FinalCourseAssignment.Domain;

namespace FinalCourseAssignment.Data.Repositories
{
    public class BaseRepository<TDto, TEntity> : IBaseRepository<TDto>
    where TDto : BaseModel
    where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> entities;
        public async Task<bool> Create(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            entity.Id = Guid.NewGuid();

            entities.Add(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> Save(BaseModel user)
        {
            throw new NotImplementedException();
        }

        public bool Update(TDto dto)
        {
            throw new NotImplementedException();
        }
    }
}