using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartApprovalSystem.Infrastructure.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApprovalSystem.Infrastructure.Extentions
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(optiones =>
                optiones.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
