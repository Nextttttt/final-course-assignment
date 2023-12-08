using AutoMapper;
using FinalCourseAssignment.Domain.Models;
using FinalCourseAssignment.Domain.Repositories;
using FinalCourseAssignment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Services.Services
{
    public class UserService : BaseService<UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHasherService _hasher;
        private readonly IJwtService _jwtToken;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IHasherService hasher,
            IJwtService jwtToken, IMapper mapper)
            :base(userRepository)
        {
            _userRepository = userRepository;
            _hasher = hasher;
            _jwtToken = jwtToken;
            _mapper = mapper;
        }

        public override async Task<Guid> Create(UserDto dto)
        {
            if(await _userRepository.GetUserByEmail(dto.Email) != null)
            {
                throw new Exception("User Exists!");
            }

            var passAndSalt = _hasher.HashPassword(dto.Password);
            dto.Password = passAndSalt.Password;
            dto.Salt = passAndSalt.Salt;
            dto.Email = dto.Email.ToLower();

            return await _userRepository.Create(dto);
        }

        public async Task<string> VerifyUserLogin(UserLoginDto loginUser)
        {
            UserDto user = await _userRepository.GetUserByEmail(loginUser.Email);

            if (user == null || !_hasher.VerifyHashedPassword(loginUser.Password, user.Password, user.Salt)) 
            {
                throw new Exception("Invalid email or password!");
            }

            return _jwtToken.GenerateJsonWebToken(user.Id);
        }
    }
}
