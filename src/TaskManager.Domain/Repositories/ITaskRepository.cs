﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task<int> CountByProjectAsync(Guid projectId);
        Task<bool> HasPendingTasksAsync(Guid projectId);
        Task<List<TaskItem>> GetByProjectIdAsync(Guid projectId);
        Task DeleteAsync(Guid taskId);
    }
}
