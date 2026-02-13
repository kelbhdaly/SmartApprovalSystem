namespace SmartApprovalSystem.API.Response
{
    public class SuccessResponse<T> : ApiResponse
    {
        public T Data { get; init; }
        public SuccessResponse(T data, int statusCode = 200)
        {
            Success = true;
            StatusCode = statusCode;
            Data = data;
        }

    }
}
