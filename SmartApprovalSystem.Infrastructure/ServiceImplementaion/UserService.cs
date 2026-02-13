using Microsoft.AspNetCore.Identity;
using SmartApprovalSystem.Application.Interfaces;
using SmartApprovalSystem.Infrastructure.Data.DbContexts;

namespace SmartApprovalSystem.Infrastructure.ServiceImplementaion
{
    public class UserService(UserManager<ApplicationUser> _userManager) : IUserService
    {
        public async Task<bool> Exists(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }

}
