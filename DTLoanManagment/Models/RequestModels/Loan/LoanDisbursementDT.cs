namespace DTLoanManagment.Models.RequestModels.Loan
{
    public class LoanDisbursementDT
    {
        public string TransactionID { get; set; } = "";
        public double DisbursementAmount { get; set; }
        public DateTime DisbursementDate { get; set; }
        public double EmiAmount { get; set; }
        public string EmiDay { get; set; } = "";
        public double CumulativeRecovery { get; set; }
        public double LastMonthRecoveryAmount { get; set; }
        public string MonthlyMaxEmiDate { get; set; } = "";
        public int LoanApplicationId { get; set; }
        public int LoanDuration { get; set; }
        public string StatusCode { get; set; } = "";
        public string Status { get; set; } = "";
    }
}
