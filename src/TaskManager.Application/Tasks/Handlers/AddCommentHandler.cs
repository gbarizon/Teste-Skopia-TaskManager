using MediatR;
using TaskManager.Application.Tasks.Commands;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Tasks.Handlers
{
    public class AddCommentHandler : IRequestHandler<AddCommentCommand, Guid>
    {
        private readonly ITaskCommentRepository _commentRepo;
        private readonly ITaskHistoryRepository _historyRepo;

        public AddCommentHandler(ITaskCommentRepository commentRepo, ITaskHistoryRepository historyRepo)
        {
            _commentRepo = commentRepo;
            _historyRepo = historyRepo;
        }

        public async Task<Guid> Handle(AddCommentCommand requestDto, CancellationToken cancellationToken)
        {
            var dto = requestDto.AddCommentDto;

            var comment = new TaskComment
            {
                TaskId = dto.TaskId,                
                Comment = dto.Content,
                UserId = dto.UserId,
                DateCreated = DateTime.UtcNow
            };
            await _commentRepo.AddAsync(comment);
            
            var history = new TaskHistory
            {
                TaskId = dto.TaskId,              
                Changes = $"Comentário adicionado: '{dto.Content}'",
                ChangedByUserId = dto.UserId,
                ChangedAt = DateTime.UtcNow
            };
            await _historyRepo.AddAsync(history);

            return comment.Id;
        }
    }
}
