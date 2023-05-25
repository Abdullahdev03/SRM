using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;


public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public string NumberPhone { get; set; }
    public string Birthplace { get; set; }
    public string Locations { get; set; }
    public string ParentFirstName { get; set; }
    public string ParentLastName { get; set; }
    public string ParentPhoneNumber { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }

}