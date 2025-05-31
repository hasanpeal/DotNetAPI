using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNETBACKEND.Models
{
    [Table("Comments")]
    public class Comment
    {
        // Primary key for the Comment entity
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Foreign key to associate the comment with a stock
        public int? StockId { get; set; }
        // Navigation property to the Stock entity ie. Stock.Id, Stock.Purchase, etc.
        public Stock? Stock { get; set; }
        public string AppUserId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public AppUser? AppUser { get; set; }
    }
}