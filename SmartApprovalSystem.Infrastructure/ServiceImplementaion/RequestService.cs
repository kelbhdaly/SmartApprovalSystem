using Microsoft.AspNetCore.Identity;
using SmartApprovalSystem.API.Exceptions;
using SmartApprovalSystem.Application.DTOs.Requests;
using SmartApprovalSystem.Application.Enums;
using SmartApprovalSystem.Application.Interfaces;
using SmartApprovalSystem.Application.Models;
using SmartApprovalSystem.Infrastructure.Data.DbContexts;
namespace SmartApprovalSystem.Infrastructure.ServiceImplementaion
{
    public class RequestService(UserManager<ApplicationUser> _userManager,
        ApplicationDbContext _dbContext , IUserContext _userContext) : IRequestService
    {
        public async Task<int> CreateRequestAsync( CreateRequestDto createRequestDto)
        {
            var userId = _userContext.UserId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            // Create the request logic here
            var request = new Request
            {
                Title = createRequestDto.Title,
                Description = createRequestDto.Description,
                RequestType = createRequestDto.RequestType,
                Status = ApprovalStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = userId
            };
            _dbContext.Requests.Add(request);
            await _dbContext.SaveChangesAsync();
            return request.Id;
        }
    }
}
