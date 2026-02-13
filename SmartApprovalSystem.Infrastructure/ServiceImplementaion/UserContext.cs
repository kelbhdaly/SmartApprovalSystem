using SmartApprovalSystem.Application.Enums;
using SmartApprovalSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SmartApprovalSystem.Infrastructure.ServiceImplementaion
{
    public class UserContext(IHttpContextAccessor _httpContextAccessor ) : IUserContext
    {
        public string UserId => _httpContextAccessor.HttpContext ?
            .User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

        public ApproverRole ApproverRole
        {
            get
            {
                var role = _httpContextAccessor.HttpContext.
                               User.FindFirst(ClaimTypes.Role)?.Value;
                return role switch
                {
                    "Manager" => ApproverRole.Manager,
                    "HR" => ApproverRole.HR,
                    _ => throw new Exception("Invalid user role")
                };
            }
        }
    }
}
