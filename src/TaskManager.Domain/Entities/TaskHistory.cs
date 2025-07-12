using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class TaskHistory
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string Changes { get; set; } = default!;
        public DateTime ChangedAt { get; set; }
        public Guid ChangedByUserId { get; set; }
    }
}
