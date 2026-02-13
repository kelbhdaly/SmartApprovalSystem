using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartApprovalSystem.API.Response;
using SmartApprovalSystem.Application.DTOs.Auth;
using SmartApprovalSystem.Application.Interfaces;

namespace SmartApprovalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController(IAuthService _authService ) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var token = await _authService.RegisterAsync(dto);
            return Ok(new SuccessResponse<string>(token));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            return Ok(new SuccessResponse<string>(token));
        }
    }
}
