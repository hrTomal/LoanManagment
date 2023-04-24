namespace DTLoanManagment.Models.ResponseModels
{
    public class LenderUserResponse
    {
        public string Message { get; set; }
        public bool DidError { get; set; }
        public string ErrorMessage { get; set; }
        public LenderUser Model { get; set; }
    }

    public class LenderUser
    {
        public int LenderUserId { get; set; }
        public string UserName { get; set; }
        public string LenderName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
    }

}
