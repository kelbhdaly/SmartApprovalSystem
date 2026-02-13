using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartApprovalSystem.Application.Interfaces;
using SmartApprovalSystem.Infrastructure.Data.DbContexts;
using SmartApprovalSystem.Infrastructure.ServiceImplementaion;

namespace SmartApprovalSystem.Infrastructure.Extentions
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(optiones =>
                optiones.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
