using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AttendanceService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AttendanceService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<AttendanceStudentDto>>> GetStudentAttendance(int studentId)
    {
        var studentAttendance = await (from a in _context.Attendances
            join s in _context.Students on a.StudentId equals s.Id
            where s.Id == studentId
            select new AttendanceStudentDto()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Course = s.Course,
                GroupName = s.Group.Name,
                AttendanceDate = a.AttendanceDate,
                IsPresent = a.IsPresent
            }).ToListAsync();


        return new Response<List<AttendanceStudentDto>>(studentAttendance);
    }

    // public async Task<Response<List<AttendanceWeek>>> GetStudentWeekAttendance(int studentId)
    // {
    //     try
    //     {
    //         var Attendances = await _context.Attendances
    //             .Where(a => a.StudentId == studentId).ToListAsync();
    //
    //         var t = Attendances.Count(x => x.IsPresent == false);
    //         var studentAttendance = await (from a in _context.AttendanceWeeks
    //             where a.StudentId == studentId
    //             select new AttendanceWeek()
    //             {
    //                 Id = a.Id,
    //                 StudentId = a.StudentId,
    //                 AttendanceDate = a.AttendanceDate,
    //                 TotalMissedHours = t,
    //             }).ToListAsync();
    //
    //         foreach (var attendanceWeek in studentAttendance) await _context.AttendanceWeeks.AddAsync(attendanceWeek);
    //         await _context.SaveChangesAsync();
    //         return new Response<List<AttendanceWeek>>(studentAttendance);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //         throw;
    //     }
    // }


    public async Task<Response<List<AttendanceGroupDto>>> GetGroupAttendance(int groupId)
    {
        var groupAttendance = await (from a in _context.Attendances
            join s in _context.Students on a.StudentId equals s.Id
            join g in _context.Groups on s.GroupId equals g.Id
            where g.Id == groupId
            select new AttendanceGroupDto()
            {
                Id = g.Id,
                Name = g.Name,
                Course = g.Course,
                IsPresent = a.IsPresent,
                AttendanceDate = a.AttendanceDate,
            }).ToListAsync();

        return new Response<List<AttendanceGroupDto>>(groupAttendance);
    }

    public async Task<int> GetStudentSumAttendance(int studentId)
    {
        var studentAttendance = await _context.Attendances
            .Where(a => a.StudentId == studentId)
            .ToListAsync();

        int totalMissedHours = studentAttendance
            .Count(a => !a.IsPresent);

        return (totalMissedHours);
    }

    public async Task<Response<AttendanceDto>> AddAttendance(AttendanceDto attendance)
    {
        var mapped = _mapper.Map<Attendance>(attendance);
        await _context.Attendances.AddAsync(mapped);
        await _context.SaveChangesAsync();

        return new Response<AttendanceDto>(_mapper.Map<AttendanceDto>(mapped));
    }
}