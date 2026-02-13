using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartApprovalSystem.API.Response;
using SmartApprovalSystem.Application.DTOs.Approvals;
using SmartApprovalSystem.Application.DTOs.ApproveRequest;
using SmartApprovalSystem.Application.DTOs.Common;
using SmartApprovalSystem.Application.DTOs.InBox;
using SmartApprovalSystem.Application.Interfaces;

namespace SmartApprovalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager , HR")]
    public class ApprovalController(IApprovalService _approvalService) : ControllerBase
    {
        [HttpPost("approve")]
        public async Task<ActionResult> Aproval (ApproveRequestDto approveRequestDto)
        {
             await _approvalService.ApproveAsync( approveRequestDto);
            return Ok(new SuccessResponse<string>("Approved successfully"));
        }
        [HttpPost("reject")]
        public async Task<IActionResult> Reject(RejectRequestDto rejectRequestDto)
        {
            await _approvalService.RejectAsync( rejectRequestDto);
            return Ok(new SuccessResponse<string>("Rejected"));
        }


        [HttpGet("Inbox")]
        public async Task<IActionResult> GetInbox(PaginationRequestDto paginationRequestDto)
        {
            var result = await _approvalService.GetPendingForApproverAsync(paginationRequestDto);
            return Ok(new SuccessResponse<IReadOnlyList<ApproverInboxItemDto>>(result));

        }
    }
}
