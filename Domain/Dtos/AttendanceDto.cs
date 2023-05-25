namespace Domain.Dtos;

public class AttendanceDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public bool IsPresent { get; set; }
}