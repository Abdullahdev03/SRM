namespace Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Course { get; set; }
    public List<Student> Students { get; set; }
    public List<Subject> Subjects  { get; set; }


}