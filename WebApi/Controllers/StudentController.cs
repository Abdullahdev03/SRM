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

public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet("Students")]
    public async Task<Response<List<StudentDto>>> GetStudent()
    {
        return await _studentService.GetStudent();
    }
    [HttpGet("StudentId")]
    public async Task<Response<StudentDto>> GetStudentById(int id)
    {
        return await _studentService.GetStudentById(id);
    }
    [HttpGet("StudentName")]
    public async Task<Response<List<StudentDto>>> GetStudentByName(string name)
    {
        return await _studentService.GetStudentByName(name);
    }
    [HttpGet("StudentCourse")]
    public async Task<Response<List<StudentDto>>> GetStudentCourse(int course)
    {
        return await _studentService.GetStudentByCourse(course);
    }

    [HttpPost("AddStudent")]
    public async Task<Response<StudentDto>> AddStudent([FromBody]StudentDto model)
    {
        if (ModelState.IsValid)
        {
            return await _studentService.AddStudent(model);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<StudentDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("UpdateStudent")]
    public async Task<Response<StudentDto>> UpdateStudent(StudentDto model)
    {
        if (ModelState.IsValid)
        {
            return await _studentService.UpdateStudent(model);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<StudentDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpDelete("DeleteStudent")]
    public async Task<Response<string>> DeleteStudent([FromBody] int Id)
    {
        return await _studentService.DeleteStudent(Id);
    }
}