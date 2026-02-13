using FluentValidation;
using SmartApprovalSystem.Application.DTOs.Approvals;

namespace SmartApprovalSystem.Application.Validators
{
    public class RejectRequestValidator : AbstractValidator<RejectRequestDto>
    {
        public RejectRequestValidator()
        {
            RuleFor(reject =>reject.RequestId)
                .GreaterThan(0).WithMessage("RequestId must be greater than 0.");
             RuleFor(reject => reject.Reason)
                 .NotEmpty().WithMessage("Reason for rejection is required.")
                 .MaximumLength(200).WithMessage("Reason must not exceed 200 characters.");
        }
    }

}
