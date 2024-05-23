using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Dtos.Stock;
using API.Helpers;

namespace API.Interfaces.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
                return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await GetByIdAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
                return stock;
            }
            return null;
        }

        public async Task<List<Stock>> GetAllAsync(ObjectQuery objectQuery)
        {
              IQueryable<Stock> query = _context.Stocks.Include(x => x.Comments);

if (!string.IsNullOrEmpty(objectQuery.symbol))
{
    query = query.Where(x => x.Symbol.Contains(objectQuery.symbol));
}

if (!string.IsNullOrEmpty(objectQuery.companyName))
{
    query = query.Where(x => x.CompanyName.Contains(objectQuery.companyName));
}

if (!string.IsNullOrWhiteSpace(objectQuery.SortBy))
{
    if (objectQuery.SortBy == "symbol")
    {
        query = objectQuery.IsDescending.HasValue ? query.OrderByDescending(x => x.Symbol) : query.OrderBy(x => x.Symbol); 
    }
    // Add more sorting conditions here if needed
     }
         var skipNumber = (objectQuery.PageNumber - 1) * objectQuery.PageSize;
        return await query.Skip(skipNumber).Take(objectQuery.PageSize).ToListAsync();
        
  }

          public async Task<Stock?> GetByIdAsync(int id)
        {
            var stock = await _context.Stocks.Include(x=>x.Comments).FirstOrDefaultAsync(x=>x.Id==id);
            return stock;
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(x=>x.Id==id);
        }

        public async Task<Stock?> UpdateAsync(int id,CreateStockRequestDto requestDto)
        {
            var stock =await GetByIdAsync(id);
            if(stock!=null){
               stock!.Symbol = requestDto.Symbol;
                stock.CompanyName = requestDto.CompanyName;
                stock.Purchase = requestDto.Purchase;
                stock.LastDividend= requestDto.LastDividend;
                stock.Industry =   requestDto.Industry;
                stock.MarketCap = requestDto.MarketCap;
               await _context.SaveChangesAsync();
                return stock;
            }
            return null;
              
        }
    }
}