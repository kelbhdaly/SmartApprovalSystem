using Microsoft.EntityFrameworkCore;
using SmartApprovalSystem.API.Exceptions;
using SmartApprovalSystem.Application.DTOs.Approvals;
using SmartApprovalSystem.Application.DTOs.ApproveRequest;
using SmartApprovalSystem.Application.DTOs.Common;
using SmartApprovalSystem.Application.DTOs.InBox;
using SmartApprovalSystem.Application.Enums;
using SmartApprovalSystem.Application.Interfaces;
using SmartApprovalSystem.Infrastructure.Data.DbContexts;

namespace SmartApprovalSystem.Infrastructure.ServiceImplementaion
{
    public class ApprovalService(ApplicationDbContext _dbContext, IUserContext _userContext) : IApprovalService
    {
        public async Task ApproveAsync(ApproveRequestDto approveRequestDto)
        {
            var userId = _userContext.UserId;
            var role = _userContext.ApproverRole;

            var request = await _dbContext.Requests
                          .Include(request => request.ApprovalSteps)
                         .FirstOrDefaultAsync(request => request.Id == approveRequestDto.RequestId);

            if (request == null)
                throw new NotFoundException("Request not found");

            var currentStep = request.ApprovalSteps
                                    .OrderBy(s => s.StepOrder)
                                    .FirstOrDefault(s => s.Status == ApprovalStatus.Pending && s.ApproverUserId == userId);

            if (currentStep == null || currentStep.ApproverUserId != userId)
                throw new UnauthorizedActionException("No pending approval steps found");

            //Approve the current step
            currentStep.Status = ApprovalStatus.Approved;
            currentStep.ActionDate = DateTime.UtcNow;
            currentStep.ApproverUserId = userId;

            //Check if there are more steps
            var hasNextStep = request.ApprovalSteps
             .Any(s => s.StepOrder > currentStep.StepOrder);
            if (!hasNextStep)
                request.Status = ApprovalStatus.Approved;

            _dbContext.Requests.Update(request);
            await _dbContext.SaveChangesAsync();
        }


        public async Task RejectAsync(RejectRequestDto rejectRequestDto)
        {
            var userId = _userContext.UserId;
            var role = _userContext.ApproverRole;
            var request = _dbContext.Requests.Include(request => request.ApprovalSteps)
                                             .FirstOrDefault(r => r.Id == rejectRequestDto.RequestId);
            if (request == null)
            {
                throw new NotFoundException("Request not found");
            }
            var currentStep = request.ApprovalSteps.OrderBy(S => S.StepOrder)
                                     .FirstOrDefault(S => S.Status == ApprovalStatus.Pending);

            if (currentStep == null || currentStep.ApproverUserId != userId)
            {
                throw new UnauthorizedActionException("No pending approval steps found");
            }
            //Reject the current step
            currentStep.Status = ApprovalStatus.Rejected;
            currentStep.ActionDate = DateTime.UtcNow;
            currentStep.ActionByUserId = userId;
            currentStep.RejectionReason = rejectRequestDto.Reason;
            request.Status = ApprovalStatus.Rejected;
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<ApproverInboxItemDto>> GetPendingForApproverAsync(PaginationRequestDto pagination)
        {
            var userId = _userContext.UserId;

            var query = _dbContext.Requests
                .Include(r => r.ApprovalSteps)
                .Where(r => r.Status == ApprovalStatus.Pending)
                .Where(r =>
                    r.ApprovalSteps
                        .OrderBy(s => s.StepOrder)
                        .FirstOrDefault(s => s.Status == ApprovalStatus.Pending)!
                        .ApproverUserId == userId)
                .Select(r => new ApproverInboxItemDto
                {
                    RequestId = r.Id,
                    Title = r.Title,
                    CreatedByUserId = r.CreatedByUserId,
                    CreatedAt = r.CreatedAt
                })
                .OrderByDescending(x => x.CreatedAt);

            var result = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return result;
        }



    }
}



