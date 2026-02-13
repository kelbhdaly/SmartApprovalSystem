using FluentValidation;
using SmartApprovalSystem.Application.DTOs.ApproveRequest;

namespace SmartApprovalSystem.Application.Validators
{
    public class ApproveRequestValidator :AbstractValidator<ApproveRequestDto>
    {
        public ApproveRequestValidator()
        {
            RuleFor(approve => approve.RequestId)
                .GreaterThan(0).WithMessage("RequestId must be greater than 0.");
          
        }
    }
}
