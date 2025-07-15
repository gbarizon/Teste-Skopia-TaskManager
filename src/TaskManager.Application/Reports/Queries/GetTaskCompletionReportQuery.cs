using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using TaskManager.Application.Reports.Dtos;

namespace TaskManager.Application.Reports.Queries
{
    public class GetTaskCompletionReportQuery : IRequest<List<TaskCompletionReportDto>>
    {
        
    }
}
