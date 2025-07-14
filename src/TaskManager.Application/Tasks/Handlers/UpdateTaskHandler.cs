using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Tasks.Commands;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Tasks.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public UpdateTaskHandler(ITaskRepository taskRepository, ITaskHistoryRepository taskHistoryRepository)
        {
            _taskRepository = taskRepository;
            _taskHistoryRepository = taskHistoryRepository;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Task;
            var task = await _taskRepository.GetByIdAsync(dto.TaskId)
                       ?? throw new Exception("Tarefa não encontrada");

            // Verificar se houve alterações
            var changes = new List<string>();

            if (dto.Title != null && dto.Title != task.Title)
                changes.Add($"Título: '{task.Title}' => '{dto.Title}'");

            if (dto.Description != null && dto.Description != task.Description)
                changes.Add($"Descrição alterada");

            if (dto.DueDate.HasValue && dto.DueDate.Value != task.DueDate)
                changes.Add($"Data de vencimento: {task.DueDate:d} => {dto.DueDate.Value:d}");

            if (dto.Status.HasValue && dto.Status.Value != task.Status)
                changes.Add($"Status: {task.Status} => {dto.Status.Value}");

            if (dto.Priority.HasValue && dto.Priority.Value != task.Priority)
                throw new Exception("Não é permitido alterar a prioridade da tarefa após a criação.");

            // Atualiza apenas os campos permitidos
            if (!string.IsNullOrEmpty(dto.Title)) task.Title = dto.Title;
            if (!string.IsNullOrEmpty(dto.Description)) task.Description = dto.Description;
            if (dto.DueDate.HasValue) task.DueDate = dto.DueDate.Value;
            if (dto.Status.HasValue) task.Status = dto.Status.Value;

            await _taskRepository.UpdateAsync(task);

            if (changes.Any())
            {
                var history = new TaskHistory
                {
                    Id = Guid.NewGuid(),
                    TaskId = task.Id,
                    Task = task,
                    ChangesDescriptions = string.Join("; ", changes),
                    ChangedAt = DateTime.UtcNow,
                    ChangedByUserId = Guid.Empty
                };
                await _taskHistoryRepository.AddAsync(history);
            }

            return Unit.Value;
        }
    }
}
