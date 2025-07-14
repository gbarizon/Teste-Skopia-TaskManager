using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using TaskManager.Application.Tasks.Commands;
using TaskManager.Application.Tasks.Dtos;
using TaskManager.Application.Tasks.Handlers;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;
using Xunit;

public class UpdateTaskHandlerTests
{
    [Fact]
    public async Task Nao_Deve_Alterar_Prioridade_Tarefa()
    {
        var existingTask = new TaskItem(
            projectId: Guid.NewGuid(),
            title: "Task",
            description: "desc",
            dueDate: DateTime.Today.AddDays(1),
            priority: Priority.Alta
        );

        existingTask.Status = Status.Pendente;

        var repoMock = new Mock<ITaskRepository>();
        repoMock.Setup(r => r.GetByIdAsync(existingTask.Id)).ReturnsAsync(existingTask);

        var historyRepoMock = new Mock<ITaskHistoryRepository>(); 

        var handler = new UpdateTaskHandler(repoMock.Object, historyRepoMock.Object);

        var updateDto = new UpdateTaskDto
        {
            TaskId = existingTask.Id,
            Priority = Priority.Baixa 
        };

        var command = new UpdateTaskCommand(updateDto);

        // Act  
        var ex = await Assert.ThrowsAsync<Exception>(() =>
            handler.Handle(command, CancellationToken.None)
        );
        // Assert  
        Assert.Contains("Não é permitido alterar a prioridade", ex.Message);
    }

    [Fact]
    public async Task Pode_Atualizar_Titulo_Sem_Mexer_Prioridade()
    {
        var existingTask = new TaskItem(
            projectId: Guid.NewGuid(),
            title: "Task",
            description: "desc",
            dueDate: DateTime.Today.AddDays(1),
            priority: Priority.Alta
        );
        existingTask.Status = Status.Pendente;

        var repoMock = new Mock<ITaskRepository>();
        repoMock.Setup(r => r.GetByIdAsync(existingTask.Id)).ReturnsAsync(existingTask);

        var historyRepoMock = new Mock<ITaskHistoryRepository>();

        var handler = new UpdateTaskHandler(repoMock.Object, historyRepoMock.Object);

        var updateDto = new UpdateTaskDto
        {
            TaskId = existingTask.Id,
            Title = "Nova Task"
        };

        var command = new UpdateTaskCommand(updateDto);

        // Act  
        await handler.Handle(command, CancellationToken.None);

        // Assert  
        repoMock.Verify(r => r.UpdateAsync(It.Is<TaskItem>(t => t.Title == "Nova Task")), Times.Once);
    }

    [Fact]
    public async Task Deve_Registrar_Historico_Ao_Atualizar_Tarefa()
    {
        var task = new TaskItem(Guid.NewGuid(), "Titulo", "desc", DateTime.Today.AddDays(1), Priority.Alta);
        task.Status = Status.Pendente;

        var repoMock = new Mock<ITaskRepository>();
        repoMock.Setup(r => r.GetByIdAsync(task.Id)).ReturnsAsync(task);

        var historyMock = new Mock<ITaskHistoryRepository>();

        var handler = new UpdateTaskHandler(repoMock.Object, historyMock.Object);

        var updateDto = new UpdateTaskDto
        {
            TaskId = task.Id,
            Title = "Novo Titulo"
        };
        var command = new UpdateTaskCommand(updateDto);

        // act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        historyMock.Verify(h => h.AddAsync(It.Is<TaskHistory>(
            hi => hi.TaskId == task.Id && hi.ChangesDescriptions.Contains("Título")
        )), Times.Once);
    }
}
