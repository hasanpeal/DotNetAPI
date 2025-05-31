using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Extensions;
using DOTNETBACKEND.Interfaces;
using DOTNETBACKEND.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DOTNETBACKEND.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IPortfolioRepository _portfolioRepository;
        public PortfolioController(IStockRepository stockRepository, UserManager<AppUser> userManager, IPortfolioRepository portfolioRepository)
        {
            _stockRepository = stockRepository;
            _userManager = userManager;
            _portfolioRepository = portfolioRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername(); ;
            var appUser = await _userManager.FindByNameAsync(username);
            var portfolios = await _portfolioRepository.GetUserPortfoliosAsync(appUser);
            return Ok(portfolios);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return NotFound("User not found");
            }

            var stock = await _stockRepository.GetStockBySymbolAsync(symbol);
            if (stock == null)
            {
                return NotFound("Stock not found");
            }

            var userPortfolio = await _portfolioRepository.GetUserPortfoliosAsync(appUser);
            if (userPortfolio.Any(e => e.Symbol == stock.Symbol))
            {
                return BadRequest("Stock already exists in portfolio");
            }

            var portfolio = new Portfolio
            {
                AppUserId = appUser.Id,
                StockId = stock.Id
            };

            await _portfolioRepository.CreateAsync(portfolio);

            if (portfolio == null)
            {
                return BadRequest("Failed to add stock to portfolio");
            }
            else
            {
                return Created();
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return NotFound("User not found");
            }

            var stock = await _stockRepository.GetStockBySymbolAsync(symbol);
            if (stock == null)
            {
                return NotFound("Stock not found");
            }

            var userPortfolio = await _portfolioRepository.GetUserPortfoliosAsync(appUser);

            var filteredStocks = userPortfolio.Where(e => e.Symbol != stock.Symbol).ToList();

            if (filteredStocks.Count == 1)
            {
                await _portfolioRepository.DeletePortfolioAsync(appUser, symbol);
            }
            else
            {
                return BadRequest("Stock not found in portfolio");
            }
            return Ok("Stock removed from portfolio");
        }




    }
}