namespace Domain.Entities;

public class Attendance
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public bool IsPresent { get; set; }
}