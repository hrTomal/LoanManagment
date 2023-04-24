using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTLoanManagment.Models.Loan
{
    [Table("LoanEMISet", Schema = "loan")]
    public class SetLoanEmi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BorrowerId { get; set; }
        [Column(TypeName ="varchar"),MaxLength(100)]
        public string? BorrowerName { get; set; }
        public int PartnerId { get; set; }
        public int ProductId { get; set; }
        public double LoanAmount { get; set; }
        public int Tenure { get; set; }
        [Column(TypeName ="varchar"),MaxLength(30)]
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
        [Column(TypeName ="varchar"),MaxLength(30)]
        public string? SavingsInstallmentType { get; set; }
        public int TypeOfSavings { get; set; }
        public double SavingsInterestRate { get; set; }
        [Column(TypeName ="smalldatetime")]
        public DateTime LoanDisbursementDate { get; set; }
        [Column(TypeName ="smalldatetime")]
        public DateTime EMIRecoveryStartDate { get; set; }
        [Column(TypeName ="varchar"),MaxLength(30)]
        public string? CreatedBy{ get; set; }
        [Column(TypeName ="smalldatetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName ="varchar"),MaxLength(30)]
        public string? UpdatedBy{ get; set; }      
        [Column(TypeName ="smalldatetime")]
        public DateTime UpdatedAt { get; set; }
        public bool isActive { get; set; }
        public bool isApproved { get; set; }
        public bool isRejected { get; set; }
        public int LoanSurveyId { get; set; }
        public bool isDisbursed { get; set; }

    }
}
