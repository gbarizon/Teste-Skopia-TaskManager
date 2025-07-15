using System;

namespace TaskManager.Application.Tasks.Dtos
{
    public class TaskCommentDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string Comment { get; set; } = default!;
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
