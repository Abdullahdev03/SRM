using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[AllowAnonymous]
[EnableCors("_myAllowSpecificOrigins")]
public class AttendanceController: ControllerBase
{
    private readonly AttendanceService _attendanceService;

    public AttendanceController(AttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpGet("Student")]
    public async Task<Response<List<AttendanceStudentDto>>> GetStudentAttendance(int studentId)
    {
        return await _attendanceService.GetStudentAttendance(studentId);
    }

    [HttpGet("Group")]
    public async Task<Response<List<AttendanceGroupDto>>> GetGroupAttendance(int groupId)
    {
        return await _attendanceService.GetGroupAttendance(groupId);
    }

    [HttpGet("StudentNB")]
    public async Task<int> GetStudentSumAttendance(int studentId)
    {
        return await _attendanceService.GetStudentSumAttendance(studentId);
    }
    // [HttpGet("StudentWeekNB")]
    // public async Task<Response<List<AttendanceWeek>>> GetStudentWeekAttendance(int studentId)
    // {
    //     return await _attendanceService.GetStudentWeekAttendance(studentId);
    // }

    [HttpPost("AddAttendance")]
    public async Task<Response<AttendanceDto>> AddAttendance(AttendanceDto attendance)
    {
        return await _attendanceService.AddAttendance(attendance);
    }
    
}