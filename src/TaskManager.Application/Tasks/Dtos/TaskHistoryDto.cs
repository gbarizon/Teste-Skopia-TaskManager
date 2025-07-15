using System;

namespace TaskManager.Application.Tasks.Dtos
{
    public class TaskHistoryDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string ChangeDescription { get; set; } = default!;
        public DateTime ChangedAt { get; set; }
        public Guid ChangedByUserId { get; set; }
    }
}
