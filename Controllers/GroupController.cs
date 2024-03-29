﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spayserver.Data.DTOs;
using spayserver.Data.Models;
using spayserver.Services.GroupService;

namespace spayserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupServices _groupServices;
        public GroupController(IGroupServices groupServices)
        {
            _groupServices = groupServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroupsAsync()
        {
            var groups = await _groupServices.GetGroupsAsync();
            if (groups == null) return NotFound();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroupByIdAsync(int id)
        {
            var groups = await _groupServices.GetGroupByIdAsync(id);
            if (groups == null) return NotFound();
            return Ok(groups);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroupByNameAsync(string groupName)
        {
            var groups = await _groupServices.GetGroupByNameAsync(groupName);
            if (groups == null) return NotFound();
            return Ok(groups);
        }

        [HttpPost("create")]
        public async Task<ActionResult<GroupDTO>> CreateGroup([FromBody] AddGroupDTO detail)
        {
            try
            {
                var group = await _groupServices.CreateGroupAsync(detail);
                return Ok(new GroupDTO
                {
                    GroupId = group.GroupId,
                    GroupName = group.GroupName
                });
            }
            catch
            {
                return BadRequest("Invalid Consumer details.");
            }
        }
    }

}