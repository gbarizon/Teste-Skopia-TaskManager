using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using TaskManager.Application.Reports.Dtos;
using TaskManager.Application.Reports.Handlers;
using TaskManager.Application.Reports.Queries;
using TaskManager.Domain.Repositories;
using Xunit;

public class GetTaskCompletionReportHandlerTests
{
    [Fact]
    public async Task Deve_Gerar_Relatorio_De_Tarefas_Concluidas_Por_Usuario()
    {
        // Arrange
        var repoMock = new Mock<ITaskHistoryRepository>();
        var user1 = Guid.NewGuid();
        var user2 = Guid.NewGuid();

        repoMock.Setup(r => r.GetTaskCompletionReportAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .ReturnsAsync(new List<(Guid, double)>
            {
                (user1, 2.0),
                (user2, 1.0)
            });

        var handler = new GetTaskCompletionReportHandler(repoMock.Object);

        // Act
        var result = await handler.Handle(new GetTaskCompletionReportQuery(), CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, x => x.UserId == user1 && x.AverageTasksCompleted == 2.0);
        Assert.Contains(result, x => x.UserId == user2 && x.AverageTasksCompleted == 1.0);
    }
}
