using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories
{
    public interface ITaskCommentRepository
    {
        Task AddAsync(TaskComment comment);
        Task<List<TaskComment>> GetByTaskIdAsync(Guid taskId);
    }
}
