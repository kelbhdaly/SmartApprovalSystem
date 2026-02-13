using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartApprovalSystem.Application.Interfaces;
using SmartApprovalSystem.Infrastructure.Data.DbContexts;
namespace SmartApprovalSystem.Infrastructure.Data.Seed
{
    public class IdentityDataSeeder(RoleManager<IdentityRole> _roleManager, ApplicationDbContext _dbContext
            , UserManager<ApplicationUser> _userManager) : IDataSeeding
    {
        public async Task IdentityDataSeedAsync()
        {
            Console.WriteLine("SEEDING STARTED");
            await _dbContext.Database.MigrateAsync();
            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
                await _roleManager.CreateAsync(new IdentityRole("HR"));
                await _roleManager.CreateAsync(new IdentityRole("Manager"));
            }


            if (! await _userManager.Users.AnyAsync())

            {
                var user01 = new ApplicationUser()
                {
                    Email = "khaled@gmail.com",
                    PhoneNumber = "1234567890",
                    UserName = "KhaledMohamed",
                    Address = "123 Main St, City, Country",
                };
                var user02 = new ApplicationUser()
                {
                    Email = "Ali@gmail.com",
                    PhoneNumber = "1234567890",
                    UserName = "Alooo",
                    Address = "123 Main St, City, Country",
                };
                var user03 = new ApplicationUser()
                {
                    Email = "A11@gmail.com",
                    PhoneNumber = "0050054",
                    UserName = "mmmmm",
                    Address = "123 Main St, City, Country", 
                };
                await _userManager.CreateAsync(user02, "k5240585");
                await _userManager.CreateAsync(user01, "1250ssdd");
                await _userManager.CreateAsync(user03, "1250ssdd");

                await _userManager.AddToRoleAsync(user01, "HR");
                await _userManager.AddToRoleAsync(user02, "Manager");
                await _userManager.AddToRoleAsync(user03, "Employee");
            }
        }
    }
}
      
