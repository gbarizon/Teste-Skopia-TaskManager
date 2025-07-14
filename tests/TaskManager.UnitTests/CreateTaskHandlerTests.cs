using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using TaskManager.Application.Tasks.Commands;
using TaskManager.Application.Tasks.Dtos;
using TaskManager.Application.Tasks.Handlers;
using TaskManager.Domain.Repositories;
using TaskManager.Domain.Entities;
using Xunit;

public class CreateTaskHandlerTests
{
    [Fact]
    public async Task Nao_Deve_Criar_Tarefa_Se_Limite_De_20_For_Atingido()
    {
        // Arrange
        var repoMock = new Mock<ITaskRepository>();
        // simula limite atingido
        repoMock.Setup(r => r.CountByProjectAsync(It.IsAny<Guid>())).ReturnsAsync(20); 

        var handler = new CreateTaskHandler(repoMock.Object);

        var dto = new CreateTaskDto
        {
            ProjectId = Guid.NewGuid(),
            Title = "Nova tarefa",
            Description = "Descrição",
            DueDate = DateTime.Today.AddDays(1),
            Priority = Priority.Alta
        };
        var command = new CreateTaskCommand(dto);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<Exception>(() =>
            handler.Handle(command, CancellationToken.None)
        );
        Assert.Contains("Limite de 20 tarefas", ex.Message);
    }
}
