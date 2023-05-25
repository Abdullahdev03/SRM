namespace Domain.Dtos;

public class AttendanceGroupDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Course { get; set; }
    public DateTime AttendanceDate { get; set; }
    public bool IsPresent { get; set; }

}