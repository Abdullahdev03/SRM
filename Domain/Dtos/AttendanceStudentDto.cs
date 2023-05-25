namespace Domain.Dtos;

public class AttendanceStudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Course { get; set; }
    public string GroupName { get; set; }
    public DateTime AttendanceDate { get; set; }
    public bool IsPresent { get; set; }
}