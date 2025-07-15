using MediatR;
using TaskManager.Application.Tasks.Dtos;

namespace TaskManager.Application.Tasks.Queries
{
    public class GetTaskByIdQuery : IRequest<TaskDto?>
    {
        public Guid Id { get; }
        public GetTaskByIdQuery(Guid id) => Id = id;
    }
}
