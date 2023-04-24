namespace DTLoanManagment.Models.Common.Response
{
    public class SingleResponseModel<T> : CoreResponseModel where T : class
    {
        public SingleResponseModel(int statusCode, string? message = null) : base(statusCode, message)
        {
        }
        public T? Model { get; set; }
    }
}
