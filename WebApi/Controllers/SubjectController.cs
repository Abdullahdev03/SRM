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

public class SubjectController: ControllerBase
{
    private readonly SubjectService _subject;

    public SubjectController(SubjectService subject)
    {
        _subject = subject;
    }
    
    [HttpGet("GetSubject")]
    public async Task<Response<List<SubjectDto>>> GetGroups()
    {
        return await _subject.GetSubject();
    }
    [HttpGet("GetStudentByName")]
    public async Task<Response<List<SubjectDto>>> GetStudentByName(string subjectName)
    {
        return await _subject.GetSubjectByName(subjectName);
    }


    [HttpPost("AddSubject")]
    public async Task<Response<SubjectDto>> AddSubject([FromBody]SubjectDto model)
    {
        if (ModelState.IsValid)
        {
            return await _subject.AddSubject(model);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<SubjectDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("UpdateSubject")]
    public async Task<Response<SubjectDto>> UpdateSubject(SubjectDto model)
    {
        if (ModelState.IsValid)
        {
            return await _subject.UpdateSubject(model);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<SubjectDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpDelete("DeleteSubject")]
    public async Task<Response<string>> DeleteSubject([FromBody] int Id)
    {
        return await _subject.DeleteSubject(Id);
    }
}