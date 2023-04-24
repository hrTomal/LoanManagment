using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTLoanManagment.Models.Accounting
{
    public class LedgerInfo
    {
        public int LedgerId { get; set; }
        public int LedgerName { get; set; }
        public string? SBName { get; set; }
        public string? Under { get; set; }
        public string? MGroup { get; set; }
        public int LevelNo { get; set; }
        public double OpeningBalance { get; set; }
        public DateTime OpeningDate { get; set; }
        public bool LedgerAcc { get; set; }
        public double Balance { get; set; }
        public string? Account { get; set; }
        public int? MerchantId { get; set; }
        public string? Courier { get; set; }
    }
}
