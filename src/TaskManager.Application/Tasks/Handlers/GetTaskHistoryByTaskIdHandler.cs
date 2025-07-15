using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Application.Tasks.Dtos;
using TaskManager.Application.Tasks.Queries;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Tasks.Handlers
{
    public class GetTaskHistoryByTaskIdHandler : IRequestHandler<GetTaskHistoryByTaskIdQuery, List<TaskHistoryDto>>
    {
        private readonly ITaskHistoryRepository _historyRepo;

        public GetTaskHistoryByTaskIdHandler(ITaskHistoryRepository historyRepo)
        {
            _historyRepo = historyRepo;
        }

        public async Task<List<TaskHistoryDto>> Handle(GetTaskHistoryByTaskIdQuery request, CancellationToken cancellationToken)
        {
            var history = await _historyRepo.GetByTaskIdAsync(request.TaskId);
            return history.Select(h => new TaskHistoryDto
            {
                Id = h.Id,
                TaskId = h.TaskId,
                ChangeDescription = h.Changes,
                ChangedAt = h.ChangedAt,
                ChangedByUserId = h.ChangedByUserId
            }).ToList();
        }
    }
}
