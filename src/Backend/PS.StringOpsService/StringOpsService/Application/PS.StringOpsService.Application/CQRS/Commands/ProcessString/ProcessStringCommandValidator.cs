using FluentValidation;

namespace PS.StringOpsService.Application.CQRS.Commands.ProcessString
{
    public class ProcessStringCommandValidator : AbstractValidator<ProcessStringCommand>
    {
        public ProcessStringCommandValidator()
        {
            RuleFor(x => x.Input)
                .NotEmpty().WithMessage("Input cannot be empty.");

            RuleFor(x => x.Operations)
                .NotNull().WithMessage("Operations cannot be null.")
                .Must(x => x.Length > 0).WithMessage("At least one operation is required.");
        }
    }
}
