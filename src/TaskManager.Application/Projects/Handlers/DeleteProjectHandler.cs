using MediatR;
using TaskManager.Application.Projects.Commands;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Projects.Handlers
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepo;
        private readonly ITaskRepository _taskRepo;

        public DeleteProjectHandler(IProjectRepository projectRepo, ITaskRepository taskRepo)
        {
            _projectRepo = projectRepo;
            _taskRepo = taskRepo;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var hasPending = await _taskRepo.HasPendingTasksAsync(request.ProjectId);
            if (hasPending)
                throw new Exception("O projeto possui tarefas pendentes. Conclua ou remova todas as tarefas antes de remover o projeto.");

            await _projectRepo.DeleteAsync(request.ProjectId); // Implemente esse método no repo
            return Unit.Value;
        }
    }
}
