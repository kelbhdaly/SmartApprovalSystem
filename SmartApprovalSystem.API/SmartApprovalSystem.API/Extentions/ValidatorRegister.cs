using FluentValidation;
using FluentValidation.AspNetCore;
using SmartApprovalSystem.Application.Validators;

namespace SmartApprovalSystem.API.Extentions
{
    public static class ValidatorRegister
    {
        public static IServiceCollection AddValidatorRegister(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateRequestValidator>();
            return services;
        }
    }
}
