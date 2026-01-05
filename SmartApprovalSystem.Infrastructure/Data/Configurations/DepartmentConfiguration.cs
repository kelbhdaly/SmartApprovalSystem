using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartApprovalSystem.Application.Models;

namespace SmartApprovalSystem.Infrastructure.Data.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
           builder.HasMany<UserProfile>()
                  .WithOne()
                  .HasForeignKey(userProfile => userProfile.DepartmentId)
                  .OnDelete(DeleteBehavior.Restrict);
            builder
                  .Property(x => x.DepartmentName)
                  .IsRequired().HasMaxLength(200);
        }
    }
}
