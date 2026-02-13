using FluentValidation;
using SmartApprovalSystem.Application.DTOs.Requests;

namespace SmartApprovalSystem.Application.Validators
{
    public class CreateRequestValidator : AbstractValidator<CreateRequestDto>
    {
        public CreateRequestValidator()
        {
            RuleFor(request => request.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
            RuleFor(request => request.Description)
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
                RuleFor(request => request.RequestType).
                IsInEnum().WithMessage("Invalid request type.");
        }
    }
}
