using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TaskManager.Application.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public Guid ProjectId { get; }
        public DeleteProjectCommand(Guid projectId) => ProjectId = projectId;
    }
}
