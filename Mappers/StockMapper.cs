using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Dtos.Stock;
using DOTNETBACKEND.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DOTNETBACKEND.Mappers
{
    // Static class to map Stock entities to StockDto objects
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                CompanyName = stock.CompanyName,
                Symbol = stock.Symbol,
                Purchase = stock.Purchase,
                MarketCap = stock.MarketCap
                // Comments are not included in the DTO to avoid circular references
            };
        }

        public static Stock ToStockCreateReqDto(this StockCreateReqDto stock)
        {
            return new Stock
            {
                CompanyName = stock.CompanyName,
                Symbol = stock.Symbol,
                Purchase = stock.Purchase,
                MarketCap = stock.MarketCap
            };
        }
    }
}