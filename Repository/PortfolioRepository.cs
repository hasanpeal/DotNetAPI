using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Data;
using DOTNETBACKEND.Interfaces;
using DOTNETBACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTNETBACKEND.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio?> DeletePortfolioAsync(AppUser user, string symbol)
        {
            var portfolio = await _context.Portfolios
                .FirstOrDefaultAsync(p => p.AppUserId == user.Id && p.Stock.Symbol == symbol);
            if (portfolio == null) return null;
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<List<Stock>> GetUserPortfoliosAsync(AppUser user)
        {
            return await _context.Portfolios
                .Where(p => p.AppUserId == user.Id)
                .Select(stock => new Stock
                {
                    Id = stock.Stock.Id,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    MarketCap = stock.Stock.MarketCap,
                }).ToListAsync();
        }
    }
}