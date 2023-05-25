using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GroupService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    
    public async Task<Response<List<GroupDto>>> GetGroups()
    {
        var response = await _context.Groups.Select(x => new GroupDto()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Course = x.Course,
            
        }).ToListAsync();
        var mapped = _mapper.Map<List<GroupDto>>(response);
        return new Response<List<GroupDto>>(mapped);
    }
    
    public async Task<Response<List<StudentDto>>> GetGroupById(int id)
    {
        var existing = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
        if (existing != null)
        {
            var response = await (from s in _context.Students
                join g in _context.Groups on s.GroupId equals g.Id
                where g.Id == id
                select new StudentDto()
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    NumberPhone = s.NumberPhone,
                    Birthplace = s.Birthplace,
                    Locations = s.Locations,
                    ParentFirstName = s.ParentFirstName,
                    ParentLastName = s.ParentLastName,
                    ParentPhoneNumber = s.ParentPhoneNumber,
                    Course = s.Course,
                    GroupName = s.Group.Name
                }).ToListAsync();

        return new Response<List<StudentDto>>(response);
        }
        return new Response<List<StudentDto>>(HttpStatusCode.NotFound,new List<string>(){$"Not found"});
    }

    public async Task<Response<List<StudentDto>>> GetStudentByGroup(string gr, int cc)
    {
        var existing = await _context.Groups.FirstOrDefaultAsync(x => x.Name.ToLower().Contains(gr.ToLower()) & x.Course == cc);
        var course = _context.Students.Where(x=>x.GroupId==existing.Id).Select(x=>new StudentDto()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            NumberPhone = x.NumberPhone,
            Birthplace = x.Birthplace,
            Locations = x.Locations,
            ParentFirstName = x.ParentFirstName,
            ParentLastName = x.ParentLastName,
            ParentPhoneNumber = x.ParentPhoneNumber,
            Course = x.Course,
            GroupName = x.Group.Name, 
        }).ToList();
        return new Response<List<StudentDto>>(course);
    }
    public async Task<Response<GroupDto>> AddGroup(GroupDto group)
    {
        var mapped = _mapper.Map<Group>(group);
        await _context.Groups.AddAsync(mapped);
        await _context.SaveChangesAsync();

        return new Response<GroupDto>(_mapper.Map<GroupDto>(mapped));
    }

    public async Task<Response<GroupDto>> UpdateGroup(GroupDto group)
    {
        var existing = await _context.Groups.FindAsync(group.Id);
        if(existing == null) return new Response<GroupDto>(HttpStatusCode.NotFound,new List<string>(){$"Not found"});
        existing.Id = group.Id;
        existing.Name = group.Name;
        existing.Description = group.Name;
        existing.Course = group.Course;
        await _context.SaveChangesAsync();
        return new Response<GroupDto>(group);


    }


    public async Task<Response<string>> DeleteGroup(int id)
    {
        var existing = await _context.Groups.FindAsync(id);
        if(existing == null) return new Response<string>(HttpStatusCode.NotFound,new List<string>(){$"Not found"});
        _context.Groups.Remove(existing);
        await _context.SaveChangesAsync();
        return new Response<string>($"Deleted");
    }
}