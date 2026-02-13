using Microsoft.OpenApi.Models;

namespace SmartApprovalSystem.API.Extentions
{
    public static class SwaggerRegisteraion
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Smart Approval System API",
                    Version = "v1",
                    Description = "API documentation for Smart Approval System"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT Token like this: Bearer {your token}"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            { Type = ReferenceType.SecurityScheme,Id = "Bearer" },
                        }, new string[] {}
                    } });
            });

            return services;
        }
    }
}
