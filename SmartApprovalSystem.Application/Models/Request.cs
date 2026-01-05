using SmartApprovalSystem.Application.Enums;

namespace SmartApprovalSystem.Application.Models
{
    public class Request
    {
        public int ID { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public RequestType  RequestType { get; set; }
        public RequestStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public string CreatedByUserId { get; set; } = default!;

    }
}
