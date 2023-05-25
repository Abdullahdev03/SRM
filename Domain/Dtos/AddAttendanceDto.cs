namespace Domain.Dtos;

public class AddAttendanceDto
{
    public int Id { get; set; }
    public bool Attended { get; set; }
    public DateTime Date { get; set; }
    public int SubjectId { get; set; }
    public int StudentId { get; set; }
}