using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Application.Tasks.Dtos;
using TaskManager.Application.Tasks.Queries;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Tasks.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskDto?>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task == null) return null;

            return new TaskDto
            {
                Id = task.Id,
                ProjectId = task.ProjectId,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority.ToString(),
                Status = task.Status.ToString()
            };
        }
    }
}
