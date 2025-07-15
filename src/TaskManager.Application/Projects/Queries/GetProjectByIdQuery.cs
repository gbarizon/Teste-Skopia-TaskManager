using MediatR;
using System;
using TaskManager.Application.Projects.Dtos;

namespace TaskManager.Application.Projects.Queries
{
    public class GetProjectByIdQuery : IRequest<ProjectDto?>
    {
        public Guid Id { get; }
        public GetProjectByIdQuery(Guid id) => Id = id;
    }
}
