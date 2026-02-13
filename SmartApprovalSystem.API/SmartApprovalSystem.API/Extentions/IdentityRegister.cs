using Microsoft.AspNetCore.Identity;
using SmartApprovalSystem.Infrastructure.Data.DbContexts;

namespace SmartApprovalSystem.API.Extentions
{
    public static class IdentityRegister
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                     .AddEntityFrameworkStores<ApplicationDbContext>()
                     .AddDefaultTokenProviders();
            return services;
        }
    }
}
