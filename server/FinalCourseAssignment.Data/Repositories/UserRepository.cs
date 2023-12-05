using AutoMapper;
using FinalCourseAssignment.Domain.Models;
using FinalCourseAssignment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Data.Repositories
{
    public class UserRepository : BaseRepository<UserDto, User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) 
        { 
        
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            UserDto user = new UserDto();
            user = _mapper.Map<UserDto>(await entities.Where(u => u.Email == email).FirstOrDefaultAsync());

           return user;
        }
    }
}