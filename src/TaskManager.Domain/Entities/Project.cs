using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Entities;

public class Project
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    [Required]
    public Guid UserId { get; set; }

    public List<TaskItem> Tasks { get; set; } = new();

}
