using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartApprovalSystem.Application.Models;
using SmartApprovalSystem.Infrastructure.Data.DbContexts;

namespace SmartApprovalSystem.Infrastructure.Data.Configurations
{
    internal class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasOne<ApplicationUser>().WithOne()
                   .HasForeignKey<UserProfile>(userProfile => userProfile.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder
                  .HasIndex(x => x.UserId)
                  .IsUnique();
            builder
                 .Property(x => x.UserId)
                 .IsRequired();
        }
    }
}
