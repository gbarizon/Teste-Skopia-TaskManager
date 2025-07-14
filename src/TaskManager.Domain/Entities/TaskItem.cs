using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public enum Priority { Baixa, Media, Alta }
    public enum Status { Pendente, EmAndamento, Concluida }

    public class TaskItem
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime DueDate { get; set; }
        public Priority Priority { get; private set; }
        public Status Status { get; set; }
        public List<TaskComment> Comments { get; set; } = new();
        public List<TaskHistory> History { get; set; } = new();

        public TaskItem(Guid projectId, string title, string description, DateTime dueDate, Priority priority)
        {
            Id = Guid.NewGuid();
            ProjectId = projectId;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = Status.Pendente;
        }       
        private TaskItem() { }
    }
}
