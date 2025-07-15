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

    /// <summary>
    /// Retorna o relatório de desempenho dos usuários, indicando a média de tarefas concluídas em determinado período.
    /// </summary>
    /// <remarks>
    /// Este endpoint está disponível apenas para usuários gerentes (autorização não implementada nesta versão).
    /// </remarks>
    /// <returns>Lista de usuários com a média de tarefas concluídas.</returns>
    [HttpGet("task-completion")]
    public async Task<IActionResult> GetTaskCompletionReport()
    {
        // Simulação de permissão de gerente (Esta parte ainda não está implementada no desafio)
        var result = await _mediator.Send(new GetTaskCompletionReportQuery());
        return Ok(result);
    }
}
