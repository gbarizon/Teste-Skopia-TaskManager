using MediatR;
using System;

namespace TaskManager.Application.Tasks.Commands
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public Guid TaskId { get; }

        public DeleteTaskCommand(Guid taskId)
        {
            TaskId = taskId;
        }
    }
}
