using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class TaskComment
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string Comment { get; set; } = default!;
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
