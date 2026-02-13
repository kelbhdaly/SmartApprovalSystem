using SmartApprovalSystem.Application.Enums;
namespace SmartApprovalSystem.Application.Models
{
    public class Request
    {
        public int Id { get; set; } 
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public RequestType  RequestType { get; set; }
        public ApprovalStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string CreatedByUserId { get; set; } = default!;
        // Navigation property
        public ICollection<ApprovalStep> ApprovalSteps { get; set; } = new List<ApprovalStep>();

    }
}
