using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class SubjectService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public SubjectService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<Response<List<SubjectDto>>> GetSubject()
    {
        var response = await _context.Subjects.Select(x => new SubjectDto()
        {
            Id = x.Id,
            SubjectName = x.SubjectName,
            TeacherName = x.TeacherName
        }).ToListAsync();
        var mapped = _mapper.Map<List<SubjectDto>>(response);
        return new Response<List<SubjectDto>>(mapped);
    }

    public async Task<Response<List<SubjectDto>>> GetSubjectByName(string name)
    {
        // filter students by name
        var subject = await _context.Subjects.Where(s => s.SubjectName.Contains(name)).Select(x=>new SubjectDto()
        {
            Id = x.Id,
            SubjectName = x.SubjectName,
            TeacherName = x.TeacherName
        }).ToListAsync();
        return new Response<List<SubjectDto>>(subject);
    }
    public async Task<Response<SubjectDto>> AddSubject(SubjectDto subject)
    {
        var mapped = _mapper.Map<Subject>(subject);
        await _context.Subjects.AddAsync(mapped);
        await _context.SaveChangesAsync();

        return new Response<SubjectDto>(_mapper.Map<SubjectDto>(mapped));
    }

    public async Task<Response<SubjectDto>> UpdateSubject(SubjectDto subject)
    {
        var existing = await _context.Subjects.FindAsync(subject.Id);
        if (existing == null)
            return new Response<SubjectDto>(HttpStatusCode.NotFound, new List<string>() { $"Not found" });
        existing.Id = subject.Id;
        existing.SubjectName = subject.SubjectName;
        existing.TeacherName = subject.TeacherName;
        await _context.SaveChangesAsync();
        return new Response<SubjectDto>(subject);
    }
    
    public async Task<Response<string>> DeleteSubject(int id)
    {
        var existing = await _context.Subjects.FindAsync(id);
        if(existing == null) return new Response<string>(HttpStatusCode.NotFound,new List<string>(){$"Not found"});
        _context.Subjects.Remove(existing);
        await _context.SaveChangesAsync();
        return new Response<string>($"Deleted");
    }
}