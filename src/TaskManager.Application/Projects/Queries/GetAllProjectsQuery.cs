using MediatR;
using System.Collections.Generic;
using TaskManager.Application.Projects.Dtos;

namespace TaskManager.Application.Projects.Queries
{
    public class GetAllProjectsQuery : IRequest<List<ProjectDto>>
    {
    }
}
