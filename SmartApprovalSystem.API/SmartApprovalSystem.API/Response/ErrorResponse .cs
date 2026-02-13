namespace SmartApprovalSystem.API.Response
{
    public class ErrorResponse : ApiResponse
    {
        public ErrorResponse(string message , int statusCode)
        {
            Success = false;
            StatusCode = statusCode;
            Message = message;

        }
    }
}
