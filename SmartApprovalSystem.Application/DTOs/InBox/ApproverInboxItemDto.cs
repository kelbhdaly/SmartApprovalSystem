namespace SmartApprovalSystem.Application.DTOs.InBox
{
    public class ApproverInboxItemDto
    {
        public int RequestId { get; set; }
        public string Title { get; set; } = default!;
        public string CreatedByUserId { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
