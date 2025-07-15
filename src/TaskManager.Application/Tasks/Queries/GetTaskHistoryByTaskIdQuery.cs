using MediatR;
using System;
using System.Collections.Generic;
using TaskManager.Application.Tasks.Dtos;

namespace TaskManager.Application.Tasks.Queries
{
    public class GetTaskHistoryByTaskIdQuery : IRequest<List<TaskHistoryDto>>
    {
        public Guid TaskId { get; }
        public GetTaskHistoryByTaskIdQuery(Guid taskId) => TaskId = taskId;
    }
}
