namespace FinanceController.Domain.Api.Errors
{
    public class AppError : Exception
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }

        public AppError(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
