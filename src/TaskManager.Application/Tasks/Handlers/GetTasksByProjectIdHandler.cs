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
    public class GetTasksByProjectIdHandler : IRequestHandler<GetTasksByProjectIdQuery, List<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTasksByProjectIdHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskDto>> Handle(GetTasksByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetByProjectIdAsync(request.ProjectId);
            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                ProjectId = t.ProjectId,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority.ToString(),
                Status = t.Status.ToString()
            }).ToList();
        }
    }
}
