using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTLoanManagment.Models.DBTableModels.Journal
{
    [Table("Ledger", Schema = "dbo")]
    public class Ledger
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LedgerId { get; set; }
        [Column(TypeName = "nvarchar"), MaxLength(250)]
        public string? SBName { get; set; }
        [Column(TypeName = "varchar"), MaxLength(30)]
        public string? Under { get; set; }
        [Column(TypeName = "varchar"), MaxLength(20)]
        public string? MGroup { get; set; }
        [Column(TypeName = "smallint")]
        public int LevelNo { get; set; }
        public double OpeningBalance { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime OpeningDate { get; set; }
        public bool LedgerAcc { get; set; }
        public double Balance { get; set; }
        [Column(TypeName = "varchar"), MaxLength(2)]
        public string? Account { get; set; }
        public int? MerchantId { get; set; }
        [Column(TypeName = "varchar"), MaxLength(100)]
        public string? Courier { get; set; }


        public ICollection<Journal>? Journals { get; set; }
    }
}
