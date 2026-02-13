using SmartApprovalSystem.Application.DTOs.Auth;

namespace SmartApprovalSystem.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
