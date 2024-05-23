using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.Stock;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.Helpers;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController( IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
       
       [HttpGet]
       public async Task<IActionResult> GetStocks([FromQuery]ObjectQuery objectQuery)
       {
           var stocks =(await _stockRepository.GetAllAsync(objectQuery))
                       .Select(s=>s.ToStockDto());
           return Ok(stocks);
       }
       [HttpGet("{id}")]
         public async Task<IActionResult> GetStock(int id)
         {
              var stock =await _stockRepository.GetByIdAsync(id);
              if(stock==null)
              {
                return NotFound();
              }
              return Ok(stock.ToStockDto());
         }
            [HttpPost]
            public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestDto stockRequestDto)
            {
                var stock = stockRequestDto.ToCreateStockRequestDto();
               await _stockRepository.CreateAsync(stock);     
                return CreatedAtAction(nameof(GetStock), new {id=stock.Id}, stock.ToStockDto());
            }
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateStock(int id, [FromBody] CreateStockRequestDto stockRequestDto)
            {
              var stock= await  _stockRepository.UpdateAsync(id,stockRequestDto);
               if(stock==null)
              {
                return NotFound();
              }
                return Ok(stock!.ToStockDto());
            }
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteStock(int id)
            {
              var stock= await _stockRepository.DeleteAsync(id);
               if(stock==null)
              {
                return NotFound();
              }
                return NoContent();
            }
    }
}