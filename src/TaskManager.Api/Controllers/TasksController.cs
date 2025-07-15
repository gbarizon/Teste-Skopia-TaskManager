using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Tasks.Commands;
using TaskManager.Application.Tasks.Dtos;
using TaskManager.Application.Tasks.Queries;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
    {
        var id = await _mediator.Send(new CreateTaskCommand(dto));
        return CreatedAtAction(nameof(GetTaskById), new { id }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var result = await _mediator.Send(new GetTaskByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> GetTasksByProjectId(Guid projectId)
    {
        var result = await _mediator.Send(new GetTasksByProjectIdQuery(projectId));
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskDto dto)
    {
        dto.TaskId = id;
        await _mediator.Send(new UpdateTaskCommand(dto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        await _mediator.Send(new DeleteTaskCommand(id));
        return NoContent();
    }
}
