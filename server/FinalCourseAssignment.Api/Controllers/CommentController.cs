using AutoMapper;
using FinalCourseAssignment.Api.ViewModels;
using FinalCourseAssignment.Domain.Models;
using FinalCourseAssignment.Domain.Services;
using FinalCourseAssignment.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

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

        [HttpPost("CreateComment")]
        public async Task<IActionResult> Create([FromQuery] CommentCreateViewModel model)
        {
            CommentDto dto = _mapper.Map<CommentDto>(model);

            await _commentService.Create(dto);
            return Created();
        }

        [HttpGet("GetComment/")]
        public async Task<IActionResult> GetById([FromHeader] Guid id)
        {
            return Ok(_mapper.Map<CommentViewModel>(await _commentService.GetById(id)));
        }

        [HttpPut("UpdateComment")]
        public async Task<IActionResult> Update([FromQuery] CommentUpdateViewModel model)
        {
            await _commentService.Update(_mapper.Map<CommentDto>(model));

            return Ok();
        }
        [HttpDelete("DeleteComment/")]
        public async Task<IActionResult> Delete([FromHeader] Guid id)
        {
            await _commentService.DeleteById(id);

            return Ok();
        }
    }
}
