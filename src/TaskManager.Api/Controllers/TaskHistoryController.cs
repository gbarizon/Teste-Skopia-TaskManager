using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Tasks.Queries;

[ApiController]
[Route("api/[controller]")]
public class TaskHistoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Lista o histórico de alterações de uma tarefa.
    /// </summary>
    /// <param name="taskId">Id da tarefa.</param>
    [HttpGet("task/{taskId}")]
    public async Task<IActionResult> GetHistoryByTaskId(Guid taskId)
    {
        var result = await _mediator.Send(new GetTaskHistoryByTaskIdQuery(taskId));
        return Ok(result);
    }
}
