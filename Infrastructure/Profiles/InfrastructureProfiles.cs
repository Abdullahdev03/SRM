using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Profiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Student ,StudentDto>().ReverseMap();
        CreateMap<Group, StudentDto>().ReverseMap();
        CreateMap<Group, GroupDto>().ReverseMap();
        CreateMap<Subject, SubjectDto>().ReverseMap();
        CreateMap<Attendance, AttendanceDto>().ReverseMap();
        CreateMap<Attendance, AttendanceGroupDto>().ReverseMap();
        CreateMap<Attendance, AttendanceStudentDto>().ReverseMap();

    }
}