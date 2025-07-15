using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project);
        Task DeleteAsync(Guid projectId);
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(Guid id);
    }
}
