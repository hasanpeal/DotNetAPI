using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNETBACKEND.Dtos.Stock
{
    public class StockUpdateReqDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Company name must be at least 1 character long")]
        [MaxLength(100, ErrorMessage = "Company name cannot exceed 10 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Symbol must be at least 1 character long")]
        [MaxLength(10, ErrorMessage = "Symbol cannot exceed 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Purchase must be a positive number")]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.1, long.MaxValue, ErrorMessage = "Market cap must be a non-negative number")]
        public long MarketCap { get; set; }
    }
}