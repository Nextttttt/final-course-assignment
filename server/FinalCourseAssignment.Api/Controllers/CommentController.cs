using AutoMapper;
using FinalCourseAssignment.Api.ViewModels;
using FinalCourseAssignment.Domain.Models;
using FinalCourseAssignment.Domain.Services;
using FinalCourseAssignment.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Security.Claims;

namespace FinalCourseAssignment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost("CreateComment")]
        public async Task<IActionResult> Create([FromBody] CommentCreateViewModel model)
        {
            CommentDto dto = _mapper.Map<CommentDto>(model);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.UserId = Guid.Parse(userId);

            var id = await _commentService.Create(dto);

            return Ok(id.ToString());
        }
        [Authorize]
        [HttpGet("GetComment/")]
        public async Task<IActionResult> GetById([FromHeader] Guid id)
        {
            return Ok(_mapper.Map<CommentViewModel>(await _commentService.GetById(id)));
        }
        [Authorize]
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            List<CommentViewModel> comments = _mapper.Map<List<CommentViewModel>>(await _commentService.GetAll());

            return Ok(comments);
        }
        [Authorize]
        [HttpPut("UpdateComment")]
        public async Task<IActionResult> Update([FromBody] CommentUpdateViewModel model)
        {
            await _commentService.Update(_mapper.Map<CommentDto>(model));

            return Ok();
        }
        [Authorize]
        [HttpDelete("DeleteComment/")]
        public async Task<IActionResult> Delete([FromHeader] Guid id)
        {
            await _commentService.DeleteById(id);

            return Ok();
        }
    }
}
