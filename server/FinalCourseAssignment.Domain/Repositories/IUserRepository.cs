using FinalCourseAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<UserDto>
    {
        public Task<UserDto> GetUserByEmail(string email);
    }
}
