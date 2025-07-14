using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TaskManager.Application.Projects.Dtos;

namespace TaskManager.Application.Projects.Validators
{
    public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
    {
        public CreateProjectDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do projeto é obrigatório");
            RuleFor(x => x.Description).NotEmpty().WithMessage("A descrição é obrigatória");
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("OwnerId é obrigatório.");
        }
    }
}
