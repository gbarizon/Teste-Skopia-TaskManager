using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Tasks.Commands;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Tasks.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Task;
            var task = await _taskRepository.GetByIdAsync(dto.TaskId)
                       ?? throw new Exception("Tarefa não encontrada");

            // Regra de negócio: não pode alterar prioridade após criação
            if (dto.Priority.HasValue && dto.Priority != task.Priority)
                throw new Exception("Não é permitido alterar a prioridade da tarefa após a criação.");

            // Atualiza apenas os campos permitidos
            if (!string.IsNullOrEmpty(dto.Title)) task.Title = dto.Title;
            if (!string.IsNullOrEmpty(dto.Description)) task.Description = dto.Description;
            if (dto.DueDate.HasValue) task.DueDate = dto.DueDate.Value;
            if (dto.Status.HasValue) task.Status = dto.Status.Value;

            await _taskRepository.UpdateAsync(task);

            return Unit.Value;
        }
    }
}
