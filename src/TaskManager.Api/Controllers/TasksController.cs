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

    /// <summary>
    /// Cria uma nova tarefa em um projeto.
    /// </summary>
    /// <param name="dto">Dados da nova tarefa.</param>
    /// <returns>Id da tarefa criada.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
    {
        var id = await _mediator.Send(new CreateTaskCommand(dto));
        return CreatedAtAction(nameof(GetTaskById), new { id }, null);
    }

    /// <summary>
    /// Retorna uma tarefa pelo Id.
    /// </summary>
    /// <param name="id">Id da tarefa.</param>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var result = await _mediator.Send(new GetTaskByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Lista todas as tarefas de um projeto.
    /// </summary>
    /// <param name="projectId">Id do projeto.</param>
    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> GetTasksByProjectId(Guid projectId)
    {
        var result = await _mediator.Send(new GetTasksByProjectIdQuery(projectId));
        return Ok(result);
    }

    /// <summary>  
    /// Atualiza uma tarefa existente.  
    /// </summary>  
    /// <param name="id">Id da tarefa a ser atualizada.</param>  
    /// <param name="dto">Dados de atualização da tarefa.</param>  
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskDto dto)
    {
        dto.TaskId = id;
        await _mediator.Send(new UpdateTaskCommand(dto));
        return NoContent();
    }

    /// <summary>
    /// Exclui uma tarefa.
    /// </summary>
    /// <param name="id">Id da tarefa.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        await _mediator.Send(new DeleteTaskCommand(id));
        return NoContent();
    }
}
