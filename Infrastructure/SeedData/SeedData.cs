using Domain.Costants;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.SeedData;

public class SeedData
{
    public static void Seed(DataContext context)
    {/*
        if (context.Roles.Any()) return;
        
        var roles = new List<IdentityRole>()
        {
            new IdentityRole(Roles.Admin){NormalizedName = Roles.Admin.ToUpper()},
            new IdentityRole(Roles.Mentor){NormalizedName = Roles.Mentor.ToUpper()},
            new IdentityRole(Roles.Student){NormalizedName = Roles.Student.ToUpper()},
            
        };

        var office = new List<Office>()
        {
            new(1, 8, 101),
            new(2, 8, 102),
            new(3, 8, 103),
            new(4, 8, 104),
            new(5, 8, 201),
            new(6, 8, 202),
            new(7, 8, 203),
        };
        var subject = new List<Subject>()
        {
            new(1, "Mathematic", "Gafurov"),
            new(2, "Fizika", "Gafurov"),
            new(3, "chemistry", "Gafurov"),
            new(4, "Java", "Gafurov"),
            new(5, "informatics", "Gafurov"),
            new(6, "Web", "Gafurov"),
            new(7, "DataBase", "Gafurov"),
        };
        var lessontime = new List<LessonTime>()
        {
            new(1, 1, 2, 3, 4, 5, 6)
        };
        var dayofweek = new List<DayOfWeek>()
        {
            new(1, "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday")
        };

        context.DayOfWeeks.AddRangeAsync(dayofweek);
        context.LessonTimes.AddRangeAsync(lessontime);
        context.Subjects.AddRangeAsync(subject);
        context.Offices.AddRangeAsync(office);
        context.Roles.AddRangeAsync(roles);
        context.SaveChangesAsync();*/

    }
}