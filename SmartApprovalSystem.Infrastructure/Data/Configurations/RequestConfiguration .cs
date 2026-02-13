using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartApprovalSystem.Application.Models;
using SmartApprovalSystem.Infrastructure.Data.DbContexts;

namespace SmartApprovalSystem.Infrastructure.Data.Configurations
{
    internal class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(request => request.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder
                  .Property(x => x.CreatedByUserId)
                  .IsRequired();
            builder.HasIndex(x => x.CreatedByUserId);
        }
    }
}
