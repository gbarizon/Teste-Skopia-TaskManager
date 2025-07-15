using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Projects.Commands;
using TaskManager.Application.Projects.Dtos;
using TaskManager.Application.Projects.Queries;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Cria um novo projeto.
    /// </summary>
    /// <param name="dto">Dados para criação do projeto.</param>
    /// <returns>Id do projeto criado.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto dto)
    {
        var id = await _mediator.Send(new CreateProjectCommand(dto));
        return CreatedAtAction(nameof(GetProjectById), new { id }, null);
    }

    /// <summary>
    /// Busca um projeto pelo Id.
    /// </summary>
    /// <param name="id">Id do projeto.</param>
    /// <returns>Projeto encontrado ou 404.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById(Guid id)
    {
        var result = await _mediator.Send(new GetProjectByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Retorna todos os projetos cadastrados.
    /// </summary>
    /// <returns>Lista de projetos.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var result = await _mediator.Send(new GetAllProjectsQuery());
        return Ok(result);
    }

    /// <summary>
    /// Exclui um projeto.
    /// </summary>
    /// <param name="id">Id do projeto.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        await _mediator.Send(new DeleteProjectCommand(id));
        return NoContent();
    }
}
