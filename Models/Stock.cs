using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNETBACKEND.Models
{
    [Table("Stocks")]
    public class Stock
    {
        // Primary key for the Stock entity
        public int Id { get; set; }
        // string.empty removes null error, add this to not have null on DB field
        public string CompanyName { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        // This specifies the precision and scale for decimal values in the database. (18,2) means 18 total digits before decimal, with 2 after the decimal point.
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        public long MarketCap { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}