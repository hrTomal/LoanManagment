namespace DTLoanManagment.Models.Common.Response
{
    public class ListResponseModel<T> : CoreResponseModel where T : class
    {
        public ListResponseModel(int statusCode, string? message = null) : base(statusCode, message)
        {
        }
        public IEnumerable<T> Model { get; set; }
    }
}
