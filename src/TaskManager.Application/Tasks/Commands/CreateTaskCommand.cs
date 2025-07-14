using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Tasks.Dtos;

namespace TaskManager.Application.Tasks.Commands
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public CreateTaskDto Task { get; }

        public CreateTaskCommand(CreateTaskDto task)
        {
            Task = task;
        }
    }
}
