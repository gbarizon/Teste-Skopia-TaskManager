namespace TaskManager.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid UserId { get; set; }
    public List<TaskItem> Tasks { get; set; } = new();
}
