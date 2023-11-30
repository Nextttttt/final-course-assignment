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

        [HttpPost("CreateDiscussion")]
        public async Task<IActionResult> Create([FromQuery] DiscussionCreateViewModel model)
        {
            DiscussionDto dto = _mapper.Map<DiscussionDto>(model);

            await _discussionService.Create(dto);
            
            return Created();
        }

        [HttpGet("GetDiscussion/")]
        public async Task<IActionResult> GetById([FromHeader] Guid id)
        {
            return Ok(_mapper.Map<DiscussionViewModel>(await _discussionService.GetById(id)));
        }

        [HttpPut("UpdateDiscussion")]
        public async Task<IActionResult> Update([FromQuery] DiscussionUpdateViewModel model)
        {
            await _discussionService.Update(_mapper.Map<DiscussionDto>(model));

            return Ok();
        }
        [HttpDelete("DeleteDiscussion/")]
        public async Task<IActionResult> Delete([FromHeader] Guid id)
        {
            await _discussionService.DeleteById(id);

            return Ok();
        }        
    }
}