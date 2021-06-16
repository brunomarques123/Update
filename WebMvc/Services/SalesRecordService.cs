using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace WebMvc.Services
{
    public class SalesRecordService
    {
        private readonly WebMvcContext _context;

        public SalesRecordService(WebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecords>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

        }
    }
}
