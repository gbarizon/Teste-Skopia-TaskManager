using System;

namespace TaskManager.Application.Tasks.Dtos
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
