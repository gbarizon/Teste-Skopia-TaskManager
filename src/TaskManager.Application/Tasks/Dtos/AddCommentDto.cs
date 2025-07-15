using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Tasks.Dtos
{
    public class AddCommentDto
    {
        public Guid TaskId { get; set; }
        public string Content { get; set; } = default!;
        public Guid UserId { get; set; }
    }
}
