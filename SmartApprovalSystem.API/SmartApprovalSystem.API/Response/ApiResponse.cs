namespace SmartApprovalSystem.API.Response
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; init; }
        public string? Message { get; init; }
    }
}
