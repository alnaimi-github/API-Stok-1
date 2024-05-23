using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Stock;
using API.Helpers;
using API.Models;

namespace API.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>>GetAllAsync(ObjectQuery objectQuery);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id,CreateStockRequestDto requestDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);
        
    }
}