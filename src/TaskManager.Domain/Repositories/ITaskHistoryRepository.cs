using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories
{
    public interface ITaskHistoryRepository
    {
        Task AddAsync(TaskHistory history);
        Task<List<TaskHistory>> GetByTaskIdAsync(Guid taskId);
    }
}
