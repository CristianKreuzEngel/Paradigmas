using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;
using trabalhoFinal.BaseDados.Models;

namespace trabalhoFinal.Services
{
    public class ProductsService
    {
        private readonly TfDbContext _dbContext;
        private readonly ILogger _logger;

        public ProductsService(TfDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public TbProduct getById(int id)
        {
            var productExisting = _dbContext.TbProducts.FirstOrDefault(product => product.Id == id);
            /*if (productExisting == null)
            {
                throw new Exception("Produto não encontrado");
            }*/
            return productExisting;
        }

           public TbProduct InsertProduct(TbProduct product)
        {
            _dbContext.TbProducts.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public TbProduct UpdateProduct(int id, TbProduct updatedProduct)
        {
            var product = _dbContext.TbProducts.Find(id);
            if (product == null) throw new Exception("Product not found");

            product.Description = updatedProduct.Description;
            product.Barcode = updatedProduct.Barcode;
            product.Barcodetype = updatedProduct.Barcodetype;
            product.Price = updatedProduct.Price;
            product.Costprice = updatedProduct.Costprice;

            _dbContext.TbProducts.Update(product);
            _dbContext.SaveChanges();
            return product;
        }

        public TbProduct GetByBarcode(string barcode)
        {
            return _dbContext.TbProducts.FirstOrDefault(p => p.Barcode == barcode);
        }

        public IEnumerable<TbProduct> SearchProducts(string description)
        {
            return _dbContext.TbProducts.Where(p => p.Description.Contains(description));
        }

        public void AdjustStock(int id, int quantity)
        {
            var product = _dbContext.TbProducts.Find(id);
            if (product == null) throw new Exception("Product not found");

            product.Stock += quantity;
            _dbContext.TbProducts.Update(product);
            _dbContext.SaveChanges();
        }

        public void LogStockChange(int productId, int quantity)
        {
            var log = new TbStockLog
            {
                Productid = productId,
                Qty = quantity,
                Createdat = DateTime.Now
            };
            _dbContext.TbStockLogs.Add(log);
            _dbContext.SaveChanges();
        }

        public bool ValidateBarcode(string barcode)
        {
            return true;
        }
        
    }
}
