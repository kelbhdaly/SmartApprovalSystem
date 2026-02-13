namespace SmartApprovalSystem.Application.DTOs.Approvals
{
    public class RejectRequestDto
    {
        public int RequestId { get; set; }
        public string Reason { get; set; } = default!;
    }
}
