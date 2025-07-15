using MediatR;
using System;
using System.Collections.Generic;
using TaskManager.Application.Tasks.Dtos;

namespace TaskManager.Application.Tasks.Queries
{
    public class GetTasksByProjectIdQuery : IRequest<List<TaskDto>>
    {
        public Guid ProjectId { get; }
        public GetTasksByProjectIdQuery(Guid projectId) => ProjectId = projectId;
    }
}
