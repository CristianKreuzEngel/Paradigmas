using System.Collections.Generic;
using System.Linq;
using ApiWebDB.BaseDados.Models2;
using ApiWebDB.DTO;
using ApiWebDB.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Trabalho_Final.BaseDados;

namespace TrabalhoFinal.Services
{
    public class StockLogService
    {
        private readonly TfDbContext _context;

        public StockLogService(TfDbContext context)
        {
            _context = context;
        }
        public List<StockLogDTO> GetLogsByProduct(int productId)
        {
            return _context.TbStockLogs
                .Include(s => s.Product)
                .Where(s => s.Productid == productId)
                .OrderByDescending(s => s.Createdat)
                .Select(s => new StockLogDTO
                {
                    Id = s.Id,
                    Productid = s.Productid,
                    Barcode = s.Product.Barcode,
                    Description = s.Product.Description,
                    Qty = s.Qty,
                    Createdat = s.Createdat
                })
                .ToList();
        }
    }
}
