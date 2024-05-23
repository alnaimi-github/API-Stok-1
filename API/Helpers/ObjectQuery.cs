using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class ObjectQuery
    {
        public string? symbol{get;set;}=string.Empty;
        public string? companyName{get;set;}=string.Empty;
        public string? SortBy { get; set; } = string.Empty;
        public bool? IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}