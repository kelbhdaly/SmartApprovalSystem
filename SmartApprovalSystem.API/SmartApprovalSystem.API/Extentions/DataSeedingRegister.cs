using SmartApprovalSystem.Application.Interfaces;

namespace SmartApprovalSystem.API.Extensions
{
    public static class DataSeedingRegister
    {
        public static async Task AddSeedDataAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var dataSeeding = scope.ServiceProvider
                                   .GetRequiredService<IDataSeeding>();

            await dataSeeding.IdentityDataSeedAsync();
        }
    }
}
