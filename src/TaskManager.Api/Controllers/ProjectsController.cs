using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Projects.Commands;
using TaskManager.Application.Projects.Dtos;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto dto)
        {
            var command = new CreateProjectCommand(dto);
            var projectId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProjectById), new { id = projectId }, null);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetProjectById(Guid id)
        {        
            return Ok();
        }
    }
}

