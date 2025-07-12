using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TaskManager.Application.Projects.Dtos;

namespace TaskManager.Application.Projects.Commands
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public CreateProjectDto Project { get; set; }

        public CreateProjectCommand(CreateProjectDto project)
        {
            Project = project;
        }
    }
}
