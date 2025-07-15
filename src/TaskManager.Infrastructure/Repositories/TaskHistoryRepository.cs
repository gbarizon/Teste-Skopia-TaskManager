using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskHistoryRepository : ITaskHistoryRepository
    {
        private readonly TaskManagerDbContext _context;

        public TaskHistoryRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskHistory history)
        {
            await _context.TaskHistories.AddAsync(history);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskHistory>> GetByTaskIdAsync(Guid taskId)
        {
            return await _context.TaskHistories
                .Where(h => h.TaskId == taskId)
                .OrderByDescending(h => h.ChangedAt)
                .ToListAsync();
        }

        public async Task<List<(Guid UserId, double AverageTasksCompleted)>> GetTaskCompletionReportAsync(DateTime startDate, DateTime endDate)
        {
            var completedHistories = await _context.TaskHistories
                .Where(h => h.Changes.Contains("Status:") && h.Changes.Contains("Concluida")
                            && h.ChangedAt >= startDate && h.ChangedAt <= endDate)
                .GroupBy(h => h.ChangedByUserId)
                .Select(g => new
                {
                    UserId = g.Key,
                    Average = g.Count() / (endDate - startDate).TotalDays
                })
                .ToListAsync();

            return completedHistories
                .Select(x => (x.UserId, x.Average))
                .ToList();
        }
    }
}
