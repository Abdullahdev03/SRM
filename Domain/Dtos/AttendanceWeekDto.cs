namespace Domain.Dtos;

public class AttendanceWeekDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public int TotalMissedHours { get; set; }
}