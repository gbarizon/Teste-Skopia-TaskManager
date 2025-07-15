using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Application.Projects.Dtos;
using TaskManager.Application.Projects.Queries;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Projects.Handlers
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto?>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDto?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null) return null;

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                UserId = project.UserId
            };
        }
    }
}
