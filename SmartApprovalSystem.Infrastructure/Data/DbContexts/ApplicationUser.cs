using Microsoft.AspNetCore.Identity;

namespace SmartApprovalSystem.Infrastructure.Data.DbContexts
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }= default!;
    }
}
