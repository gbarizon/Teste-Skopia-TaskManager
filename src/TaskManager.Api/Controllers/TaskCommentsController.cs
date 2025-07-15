using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Tasks.Commands;
using TaskManager.Application.Tasks.Dtos;
using TaskManager.Application.Tasks.Queries;

[ApiController]
[Route("api/[controller]")]
public class TaskCommentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskCommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] AddCommentDto dto)
    {
        var id = await _mediator.Send(new AddCommentCommand(dto));
        return CreatedAtAction(nameof(GetCommentsByTaskId), new { taskId = dto.TaskId }, null);
    }

    [HttpGet("task/{taskId}")]
    public async Task<IActionResult> GetCommentsByTaskId(Guid taskId)
    {
        var result = await _mediator.Send(new GetCommentsByTaskIdQuery(taskId));
        return Ok(result);
    }
}
