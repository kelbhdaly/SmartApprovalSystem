namespace SmartApprovalSystem.Application.DTOs.Auth
{
    public class RegisterDto
    {
        public string UserName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
