using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class TaskHistory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [ForeignKey("TaskId")]
        public required TaskItem Task { get; set; }

        [Required]
        [MaxLength(500)]
        public required string ChangesDescriptions { get; set; }

        [Required]
        public DateTime ChangedAt { get; set; }

        [Required]
        public Guid ChangedByUserId { get; set; }

        public TaskHistory(Guid taskId, string changes, Guid changedByUserId)
        {
            Id = Guid.NewGuid();
            TaskId = taskId;
            ChangesDescriptions = changes;
            ChangedByUserId = changedByUserId;
            ChangedAt = DateTime.UtcNow;
        }

        public TaskHistory() { }
    }
}
