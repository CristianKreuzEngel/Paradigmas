using trabalhoFinal.BaseDados.Models;
using trabalhoFinal.Services.DTOs;

namespace trabalhoFinal.Services.Parser
{

    public static class ProductsParser
    {
        public static TbProduct ToEntity(ProductsDTO dto)
        {
            return new TbProduct
            {
                Id = dto.Id,
                Description = dto.Description,
                Barcode = dto.Barcode,
                Barcodetype = dto.BarcodeType,
                Stock = dto.Stock,
                Price = dto.Price,
                Costprice = dto.CostPrice
            };
        }
    }
}