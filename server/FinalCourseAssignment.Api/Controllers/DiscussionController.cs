using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalCourseAssignment.Domain.Services;
using FinalCourseAssignment.Domain.Models;
using AutoMapper;
using FinalCourseAssignment.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace FinalCourseAssignment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscussionController : ControllerBase
    {
        private readonly IDiscussionService _discussionService;
        private readonly IMapper _mapper;

        public DiscussionController(IDiscussionService discussionService, IMapper mapper)
        {
            _discussionService = discussionService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost("CreateDiscussion")]
        public async Task<IActionResult> Create([FromBody] DiscussionCreateViewModel model)
        {
            DiscussionDto dto = _mapper.Map<DiscussionDto>(model);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.UserId = Guid.Parse(userId);

            var id = await _discussionService.Create(dto);
            
            return Ok(id.ToString());
        }
        [Authorize]
        [HttpGet("GetDiscussion/")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            return Ok(_mapper.Map<DiscussionViewModel>(await _discussionService.GetById(id)));
        }
        [Authorize]
        [HttpGet("Top")]
        public async Task<IActionResult> GetTopFiveDiscussions()
        {
            List<DiscussionTitleAndIdViewModel> discussions = _mapper.Map<List<DiscussionTitleAndIdViewModel>>(await _discussionService.GetTopFiveDiscussions());

            return Ok(discussions);
        }
        [Authorize]
        [HttpGet("My")]
        public async Task<IActionResult> GetAllByUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id = Guid.Parse(userId);
            List<DiscussionViewModel> discussions = _mapper.Map<List<DiscussionViewModel>>(await _discussionService.GetAllByUserId(id));

            return Ok(discussions);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            List<DiscussionViewModel> discussions = _mapper.Map<List<DiscussionViewModel>>(await _discussionService.GetAll());

            return Ok(discussions);
        }
        [Authorize]
        [HttpPut("UpdateDiscussion")]
        public async Task<IActionResult> Update([FromBody] DiscussionUpdateViewModel model)
        {
            await _discussionService.Update(_mapper.Map<DiscussionDto>(model));

            return Ok();
        }
        [Authorize]
        [HttpDelete("DeleteDiscussion/")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _discussionService.DeleteById(id);

            return Ok();
        }        
    }
}