using AutoMapper;
using FinalCourseAssignment.Api.ViewModels;
using FinalCourseAssignment.Domain.Models;
using FinalCourseAssignment.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace FinalCourseAssignment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDto user = _mapper.Map<UserDto>(model);

            try
            {
                await _userService.Create(user);
            }
            catch
            {
                return BadRequest("User with this Email, already exists!");
            }
            return Created();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }

            UserLoginDto user = _mapper.Map<UserLoginDto>(model);
            string json;
            try 
            { 
                var token = await _userService.VerifyUserLogin(user); 
                json = JsonConvert.SerializeObject(token);
            }   
            catch
            {
                return BadRequest("Email or Password Invalid!");
            }
            
            //remove "Bearer " when testing outside Swagger
            //string json = JsonConvert.SerializeObject("Bearer " + token);
           

            return Ok(json);
        }
        [Authorize]
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            List<UserViewModel> users = _mapper.Map<List<UserViewModel>>(await _userService.GetAll());

            return Ok(users);
        }
        [Authorize]
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update([FromBody] UserUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserDto user = _mapper.Map<UserDto>(model);

            if(await _userService.Update(user))
            {
                return Ok();
            }

            return BadRequest(ModelState);
        }
        [Authorize]
        [HttpDelete("DeleteUser/")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            if(await _userService.DeleteById(id))
            {
                return Ok();
            }

            return BadRequest(ModelState);
        }

    }
}
