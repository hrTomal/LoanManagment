namespace DTLoanManagment.Models.RequestModels.Loan
{
    public class LoanDisbursementResponse
    {
        public class ApiResponse<T>
        {
            public string Message { get; set; }
            public bool DidError { get; set; }
            public string ErrorMessage { get; set; }
            public T Model { get; set; }
        }
        public class TransactionDetails
        {
            public string TransactionID { get; set; }
            public decimal DisbursementAmount { get; set; }
            public DateTime DisbursementDate { get; set; }
            public decimal EmiAmount { get; set; }
            public string EmiDay { get; set; }
            public decimal CumulativeRecovery { get; set; }
            public decimal LastMonthRecoveryAmount { get; set; }
            public string MonthlyMaxEmiDate { get; set; }
            public int LoanApplicationId { get; set; }
            public int LoanDuration { get; set; }
            public string StatusCode { get; set; }
            public string Status { get; set; }
        }
    }
}
