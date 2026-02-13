using SmartApprovalSystem.Application.DTOs.Approvals;
using SmartApprovalSystem.Application.DTOs.ApproveRequest;
using SmartApprovalSystem.Application.DTOs.Common;
using SmartApprovalSystem.Application.DTOs.InBox;
namespace SmartApprovalSystem.Application.Interfaces
{
    public interface IApprovalService
    {
        Task ApproveAsync( ApproveRequestDto approveRequestDto);
        Task RejectAsync( RejectRequestDto  rejectRequestDto);
        public  Task<IReadOnlyList<ApproverInboxItemDto>> GetPendingForApproverAsync(PaginationRequestDto pagination);
    }
}
