using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using TaskManager.Application.Projects.Commands;
using TaskManager.Application.Projects.Handlers;
using TaskManager.Domain.Repositories;
using Xunit;

public class DeleteProjectHandlerTests
{
    [Fact]
    public async Task Nao_Deve_Remover_Projeto_Com_Tarefas_Pendentes()
    {
        var projectId = Guid.NewGuid();

        var projectRepoMock = new Mock<IProjectRepository>();
        var taskRepoMock = new Mock<ITaskRepository>();
        taskRepoMock.Setup(r => r.HasPendingTasksAsync(projectId)).ReturnsAsync(true);

        var handler = new DeleteProjectHandler(projectRepoMock.Object, taskRepoMock.Object);

        var command = new DeleteProjectCommand(projectId);

        var ex = await Assert.ThrowsAsync<Exception>(() =>
            handler.Handle(command, CancellationToken.None)
        );
        Assert.Contains("tarefas pendentes", ex.Message);
    }
}
