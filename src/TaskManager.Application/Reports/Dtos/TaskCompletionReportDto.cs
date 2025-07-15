using System;

namespace TaskManager.Application.Reports.Dtos
{
    public class TaskCompletionReportDto
    {
        public Guid UserId { get; set; }       
        public double AverageTasksCompleted { get; set; }
    }
}
