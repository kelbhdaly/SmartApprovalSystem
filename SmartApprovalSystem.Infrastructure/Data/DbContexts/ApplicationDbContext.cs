using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartApprovalSystem.Application.Models;

namespace SmartApprovalSystem.Infrastructure.Data.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        #region Table In DataBase

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ApprovalStep> ApprovalSteps { get; set; }

        #endregion
    }
}
