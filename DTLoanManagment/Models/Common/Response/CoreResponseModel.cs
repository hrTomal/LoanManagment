using Microsoft.AspNetCore.Http;

namespace DTLoanManagment.Models.Common.Response
{
    public class CoreResponseModel
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public CoreResponseModel(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageFromStatusCode(statusCode);
        }
        private string? GetDefaultMessageFromStatusCode(int statusCode) => statusCode switch
        {
            200 => "Response Ok",
            201 => "Created Successfully",
            400 => "A bad request you have made",
            401 => "Unauthorized",
            403 => "You don’t have permission to access [directory] on this server",
            404 => "Resourse not found",
            405 => "Request method is not right",
            408 => "Request Timeout, There was a problem on our server. Please wait and try again later.",
            498 => "Invalid Access Token",
            499 => "Access Token Required",
            500 => "Server Error",
            _ => null
        };
    }
}
