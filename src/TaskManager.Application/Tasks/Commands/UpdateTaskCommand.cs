using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TaskManager.Application.Tasks.Dtos;

namespace TaskManager.Application.Tasks.Commands
{
    public class UpdateTaskCommand : IRequest<Unit>
    {
        public UpdateTaskDto Task { get; }

        public UpdateTaskCommand(UpdateTaskDto task)
        {
            Task = task;
        }
    }
}
