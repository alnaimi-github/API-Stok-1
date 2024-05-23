using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Stock
{
    public class CreateStockRequestDto
    {
       public string Symbol { get; set; }=string.Empty;
        public string CompanyName { get; set; }=string.Empty;
        public decimal Purchase{get;set;}
        public decimal LastDividend{get;set;}
        public string Industry { get; set; }=string.Empty;
        public long  MarketCap { get; set; }  
    }
}