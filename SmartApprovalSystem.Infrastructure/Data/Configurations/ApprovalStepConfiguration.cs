using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartApprovalSystem.Application.Models;

namespace SmartApprovalSystem.Infrastructure.Data.Configurations
{
    internal class ApprovalStepConfiguration : IEntityTypeConfiguration<ApprovalStep>
    {
        public void Configure(EntityTypeBuilder<ApprovalStep> builder)
        {
            builder
                .HasOne(a => a.Request)
                .WithMany(r => r.ApprovalSteps)
                .HasForeignKey(a => a.RequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.RequestId)
                   .IsRequired();

            builder.HasIndex(x => x.RequestId);
        }
    }

}
