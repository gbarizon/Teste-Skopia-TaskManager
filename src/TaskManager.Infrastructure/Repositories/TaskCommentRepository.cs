using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskCommentRepository : ITaskCommentRepository
    {
        private readonly TaskManagerDbContext _context;

        public TaskCommentRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskComment comment)
        {
            await _context.TaskComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskComment>> GetByTaskIdAsync(Guid taskId)
        {
            return await _context.TaskComments
                .Where(c => c.TaskId == taskId)
                .OrderByDescending(c => c.DateCreated)
                .ToListAsync();
        }
    }
}
