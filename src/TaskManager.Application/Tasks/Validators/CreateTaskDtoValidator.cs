using FluentValidation;
using TaskManager.Application.Tasks.Dtos;

namespace TaskManager.Application.Tasks.Validators
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .WithMessage("ProjectId é obrigatório.");
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("O título é obrigatório.")
                .MaximumLength(100);
            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Tamanho máximo para descrição ultrapassado."); 
            RuleFor(x => x.DueDate)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("A data de vencimento deve ser hoje ou futura.");
            RuleFor(x => x.Priority)
                .IsInEnum()
                .WithMessage("Prioridade inválida");
        }
    }
}
