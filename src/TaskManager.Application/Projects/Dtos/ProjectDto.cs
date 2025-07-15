using System;

namespace TaskManager.Application.Projects.Dtos
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public Guid UserId { get; set; }        
    }
}
