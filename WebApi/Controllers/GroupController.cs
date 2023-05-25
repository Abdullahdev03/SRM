using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[AllowAnonymous]
[EnableCors("_myAllowSpecificOrigins")]
public class GroupController : ControllerBase
{
    private readonly GroupService _groupService;

    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }
    
    [HttpGet("Groups")]
    public async Task<Response<List<GroupDto>>> GetGroups()
    {
        return await _groupService.GetGroups();
    }
    [HttpGet("/GroupId")]
    public async Task<Response<List<StudentDto>>> GetGroupById(int id)
    {
        return await _groupService.GetGroupById(id);
    }

    [HttpGet("StudentGroup")]
    public async Task<Response<List<StudentDto>>> GetStudentGroup(string groupName, int course)
    {
        return await _groupService.GetStudentByGroup(groupName,course);
    }
    [HttpPost("AddGroup")]
    public async Task<Response<GroupDto>> AddGroup([FromBody]GroupDto model)
    {
        if (ModelState.IsValid)
        {
            return await _groupService.AddGroup(model);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<GroupDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("UpdateGroup")]
    public async Task<Response<GroupDto>> UpdateGroup(GroupDto model)
    {
        if (ModelState.IsValid)
        {
            return await _groupService.UpdateGroup(model);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<GroupDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpDelete("DeleteGroup")]
    public async Task<Response<string>> DeleteGroup([FromBody] int Id)
    {
        return await _groupService.DeleteGroup(Id);
    }
    
}