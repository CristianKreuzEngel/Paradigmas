using ApiWebDB.BaseDados.Models2;
using ApiWebDB.Services.Exceptions;
using System.Collections.Generic;

namespace ApiWebDB.Services.Validate
{
    public class SaleValidator
    {
        public static void Validate(IEnumerable<TbSale> sales)
        {
            foreach (var sale in sales)
            {
                ValidateSale(sale);
            }
        }

        private static void ValidateSale(TbSale sale)
        {
            if (string.IsNullOrEmpty(sale.Code))
                throw new InvalidEntityException("Código da venda é obrigatório.");

            if (sale.Price <= 0)
                throw new InvalidEntityException("O preço da venda deve ser maior que zero.");

            if (sale.Qty <= 0)
                throw new InvalidEntityException("A quantidade vendida deve ser maior que zero.");
        }
    }
}
