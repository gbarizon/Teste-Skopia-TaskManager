using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TaskManager.Application.Tasks.Dtos;

namespace TaskManager.Application.Tasks.Commands
{
    public class AddCommentCommand : IRequest<Guid>
    {
        public AddCommentDto AddCommentDto { get; }

        public AddCommentCommand(AddCommentDto addCommentDto)
        {
            AddCommentDto = addCommentDto;
        }
    }
}
