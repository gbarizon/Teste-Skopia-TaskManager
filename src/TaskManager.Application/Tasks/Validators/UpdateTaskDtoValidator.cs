using FluentValidation;
using TaskManager.Application.Tasks.Dtos;

namespace TaskManager.Application.Tasks.Validators
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskDto>
    {
        public UpdateTaskDtoValidator()
        {
            RuleFor(x => x.TaskId)
                .NotEmpty().WithMessage("O id da tarefa é obrigatório.");

            RuleFor(x => x.Title)
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.DueDate)
                .GreaterThanOrEqualTo(DateTime.Today)
                .When(x => x.DueDate.HasValue)
                .WithMessage("A data de vencimento deve ser hoje ou futura.");

            RuleFor(x => x.Priority)
                .IsInEnum()
                .When(x => x.Priority.HasValue);

            RuleFor(x => x.Status)
                .IsInEnum()
                .When(x => x.Status.HasValue);
        }
    }
}
