using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Models;

namespace DOTNETBACKEND.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfoliosAsync(AppUser user);
        Task<Portfolio> CreateAsync(Portfolio portfolio);
        Task<Portfolio?> DeletePortfolioAsync(AppUser user, string symbol);
    }
}