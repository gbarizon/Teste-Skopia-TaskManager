using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Domain.Repositories;
using TaskManager.Application.Tasks.Commands;

namespace TaskManager.Application.Tasks.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _taskRepository.DeleteAsync(request.TaskId);
            return Unit.Value;
        }
    }
}
