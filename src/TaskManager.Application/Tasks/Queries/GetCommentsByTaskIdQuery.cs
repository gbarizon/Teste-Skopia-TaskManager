using MediatR;
using System;
using System.Collections.Generic;
using TaskManager.Application.Tasks.Dtos;

namespace TaskManager.Application.Tasks.Queries
{
    public class GetCommentsByTaskIdQuery : IRequest<List<TaskCommentDto>>
    {
        public Guid TaskId { get; }
        public GetCommentsByTaskIdQuery(Guid taskId) => TaskId = taskId;
    }
}
