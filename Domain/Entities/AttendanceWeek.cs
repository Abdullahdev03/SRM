namespace Domain.Entities;

public class AttendanceWeek
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public int TotalMissedHours { get; set; }
}