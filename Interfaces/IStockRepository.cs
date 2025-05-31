using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Dtos.Stock;
using DOTNETBACKEND.Helpers;
using DOTNETBACKEND.Models;

namespace DOTNETBACKEND.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllStocksAsync(QueryObject query);
        Task<Stock?> GetStockByIdAsync(int id);
        Task<Stock?> GetStockBySymbolAsync(string symbol);
        Task<Stock> CreateStockAsync(Stock stock);
        Task<Stock?> UpdateStockAsync(int id, StockUpdateReqDto stockDto);
        Task<Stock?> DeleteStockAsync(int id);
        Task<bool> StockExistsAsync(int id);
    }
}