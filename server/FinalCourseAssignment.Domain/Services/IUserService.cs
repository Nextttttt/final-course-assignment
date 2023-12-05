using FinalCourseAssignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Domain.Services
{
    public interface IUserService : IBaseService<UserDto>
    {
        public Task<string> VerifyUserLogin(UserLoginDto user);
    }
}
