using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }

    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Attendance> Attendances { get; set; }

    public DbSet<AttendanceWeek> AttendanceWeeks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}