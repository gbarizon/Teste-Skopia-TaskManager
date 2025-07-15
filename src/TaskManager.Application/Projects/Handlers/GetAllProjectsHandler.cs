using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Application.Projects.Dtos;
using TaskManager.Application.Projects.Queries;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Projects.Handlers
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                UserId = p.UserId
            }).ToList();
        }
    }
}
