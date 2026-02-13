namespace SmartApprovalSystem.API.Exceptions
{
    public class UnauthorizedActionException : Exception
    {
        public UnauthorizedActionException(string message) :base(message)
        {
            
        }
    }
}
