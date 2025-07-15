using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Application.Tasks.Dtos;
using TaskManager.Application.Tasks.Queries;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Tasks.Handlers
{
    public class GetCommentsByTaskIdHandler : IRequestHandler<GetCommentsByTaskIdQuery, List<TaskCommentDto>>
    {
        private readonly ITaskCommentRepository _commentRepo;

        public GetCommentsByTaskIdHandler(ITaskCommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public async Task<List<TaskCommentDto>> Handle(GetCommentsByTaskIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepo.GetByTaskIdAsync(request.TaskId);
            return comments.Select(c => new TaskCommentDto
            {
                Id = c.Id,
                TaskId = c.TaskId,
                Comment = c.Comment,
                UserId = c.UserId,
                DateCreated = c.DateCreated
            }).ToList();
        }
    }
}
