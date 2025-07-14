using MediatR;
using TaskManager.Application.Tasks.Commands;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Tasks.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Task;
            var taskCount = await _taskRepository.CountByProjectAsync(dto.ProjectId);

            if (taskCount >= 20)
                throw new Exception("Limite de 20 tarefas por projeto atingido.");

            var task = new TaskItem(
                dto.ProjectId,
                dto.Title,
                dto.Description,
                dto.DueDate,
                dto.Priority
            );

            await _taskRepository.AddAsync(task);
            return task.Id;
        }
    }
}
