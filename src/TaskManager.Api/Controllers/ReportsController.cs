using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Reports.Queries;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("task-completion")]
    public async Task<IActionResult> GetTaskCompletionReport()
    {
        // Simulação de permissão de gerente (Esta parte ainda não está implementada no desafio)
        var result = await _mediator.Send(new GetTaskCompletionReportQuery());
        return Ok(result);
    }
}
