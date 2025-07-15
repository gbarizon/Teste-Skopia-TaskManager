using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using TaskManager.Application.Tasks.Commands;
using TaskManager.Application.Tasks.Dtos;
using TaskManager.Application.Tasks.Handlers;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;
using Xunit;

public class AddCommentHandlerTests
{
    [Fact]
    public async Task Deve_Adicionar_Comentario_E_Registrar_Historico()
    {
        // Arrange
        var taskId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var dto = new AddCommentDto
        {
            TaskId = taskId,
            Content = "Novo comentário",
            UserId = userId
        };
        var commentRepoMock = new Mock<ITaskCommentRepository>();
        var historyRepoMock = new Mock<ITaskHistoryRepository>();

        var handler = new AddCommentHandler(commentRepoMock.Object, historyRepoMock.Object);
        var command = new AddCommentCommand(dto);

        // Act
        var resultId = await handler.Handle(command, CancellationToken.None);

        // Assert
        commentRepoMock.Verify(r => r.AddAsync(It.Is<TaskComment>(
            c => c.TaskId == taskId && c.Comment == "Novo comentário" && c.UserId == userId
        )), Times.Once);

        historyRepoMock.Verify(r => r.AddAsync(It.Is<TaskHistory>(
            h => h.TaskId == taskId && h.Changes.Contains("Comentário")
        )), Times.Once);
    }
}
