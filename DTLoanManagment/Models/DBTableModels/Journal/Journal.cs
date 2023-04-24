using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTLoanManagment.Models.DBTableModels.Journal
{
    [Table("Journal", Schema = "dbo")]
    public class Journal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Jid { get; set; }        
        [Column(TypeName = "varchar"), MaxLength(2500)]
        public string Description { get; set; } = "";
        public double Debit { get; set; }
        public double Credit { get; set; }
        [Column(TypeName = "varchar"), MaxLength(2)]
        public string AccType { get; set; } = "";
        [Column(TypeName = "smalldatetime")]
        public DateTime JDate { get; set; }
        public int Tno { get; set; }
        [Column(TypeName = "varchar"), MaxLength(10)]
        public string Notify { get; set; } = "";
        [Column(TypeName = "smalldatetime")]
        public DateTime PostDate { get; set; }
        public bool isLock{ get; set; }
        public int UserID { get; set; }
        public int ApproveBy { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime ApprovalDate { get; set; }
        public int UpdateBy { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime UpdateDate { get; set; }
        public int BorrowerId { get; set; }
        public int LoanId { get; set; }



        [ForeignKey("LedgerId")]
        public int LedgerId { get; set; }
        public Ledger? Ledger { get; set; }

    }
}
