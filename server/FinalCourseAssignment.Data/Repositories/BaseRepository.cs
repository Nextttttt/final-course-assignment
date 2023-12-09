using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalCourseAssignment.Data.Entities;
using FinalCourseAssignment.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinalCourseAssignment.Data.Repositories
{
    public class BaseRepository<TDto, TEntity> : IBaseRepository<TDto>
    where TDto : BaseModel
    where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> entities;

        public BaseRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            entities = dbContext.Set<TEntity>();
        }

        public virtual async Task<Guid> Create(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            entity.Id = Guid.NewGuid();

            entities.Add(entity);
            if(await _dbContext.SaveChangesAsync() != 0)
            {
                return entity.Id;
            }

            throw new Exception("Entity not Created!");
        }

        public async Task<bool> DeleteById(Guid id)
        {
            _dbContext.Remove(entities.FirstOrDefault(e => e.Id == id));
            
            if(await _dbContext.SaveChangesAsync() != 0)
            {
                return true;
            }
            return false;
        }

        public virtual async Task<List<TDto>> GetAll()
        {
            return _mapper.Map<List<TDto>>(await entities.ToListAsync());
        }

        public virtual async Task<TDto> GetById(Guid id)
        {
            TEntity entity = await entities.FirstOrDefaultAsync(e => e.Id == id);
            TDto dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        public virtual async Task<bool> Update(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);

            if(entities.Any(e => e.Id == entity.Id))
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}