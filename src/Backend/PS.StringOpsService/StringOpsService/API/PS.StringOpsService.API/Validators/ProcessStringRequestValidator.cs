using FluentValidation;
using PS.StringOpsService.API.DTOs;

namespace PS.StringOpsService.API.Validators
{
    public class ProcessStringRequestValidator : AbstractValidator<ProcessStringRequest>
    {
        public ProcessStringRequestValidator()
        {
            RuleFor(x => x.Input)
                .NotEmpty().WithMessage("Input cannot be empty.");

            RuleFor(x => x.Operations)
                .NotNull().WithMessage("Operations cannot be null.")
                .Must(x => x.Length > 0).WithMessage("At least one operation is required.");
        }
    }
}
