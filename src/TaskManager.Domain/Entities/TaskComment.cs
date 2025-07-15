using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class TaskComment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TaskId { get; set; }

        [ForeignKey("TaskId")]
        public TaskItem? Task { get; set; } // Declared as nullable to resolve CS8618

        [Required]
        [MaxLength(500)]
        public required string Comment { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public TaskComment(Guid taskId, string comment, Guid userId)
        {
            Id = Guid.NewGuid();
            TaskId = taskId;
            Comment = comment;
            UserId = userId;
            DateCreated = DateTime.UtcNow;
        }

        public TaskComment() { }
    }
}
