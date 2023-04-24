using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTLoanManagment.Models.Loan
{
    public class SetLoanEmiRequest
    {
        public int Id { get; set; }
        public int BorrowerId { get; set; }
        public string? BorrowerName { get; set; }
        public int PartnerId { get; set; }
        public int ProductId { get; set; }
        public double LoanAmount { get; set; }
        public int Tenure { get; set; }
        public string? InstallmentType { get; set; }
        public int NoOfEMIs { get; set; }
        public double LoanProcessingFees { get; set; }
        public double PassBookCharges { get; set; }
        public double OtherCharges { get; set; }
        public double VatOnLoanProcessingFees { get; set; }
        public double InterestRate { get; set; }
        public double PrincipalAmountEMI { get; set; }
        public double PrincipalWithInterestAmountEMI { get; set; }
        public double SavingsDepositAmount { get; set; }
        public string? SavingsInstallmentType { get; set; }
        public int TypeOfSavings { get; set; }
        public double SavingsInterestRate { get; set; }
        public DateTime LoanDisbursementDate { get; set; }
        public DateTime EMIRecoveryStartDate { get; set; }
        public string? CreatedBy{ get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy{ get; set; }
        public DateTime UpdatedAt { get; set; }
        //public int LoanSurveyId{ get; set; }
    }
}
