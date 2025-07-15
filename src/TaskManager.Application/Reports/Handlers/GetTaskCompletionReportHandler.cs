using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Application.Reports.Dtos;
using TaskManager.Application.Reports.Queries;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Reports.Handlers
{
    public class GetTaskCompletionReportHandler : IRequestHandler<GetTaskCompletionReportQuery, List<TaskCompletionReportDto>>
    {
        private readonly ITaskHistoryRepository _historyRepository;

        public GetTaskCompletionReportHandler(ITaskHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<List<TaskCompletionReportDto>> Handle(GetTaskCompletionReportQuery request, CancellationToken cancellationToken)
        {
            var startDate = DateTime.UtcNow.AddDays(-30);
            var endDate = DateTime.UtcNow;

            var reportData = await _historyRepository.GetTaskCompletionReportAsync(startDate, endDate);

            return reportData.Select(x => new TaskCompletionReportDto
            {
                UserId = x.UserId,
                AverageTasksCompleted = x.AverageTasksCompleted
            }).ToList();
        }
    }
}
