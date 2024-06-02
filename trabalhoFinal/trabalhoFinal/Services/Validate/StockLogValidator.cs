using ApiWebDB.BaseDados.Models2;
using ApiWebDB.Services.Exceptions;

namespace ApiWebDB.Services.Validate
{
    public class StockLogValidator
    {
        public static void Validate(TbStockLog stockLog)
        {
            if (stockLog.Createdat == default)
                throw new InvalidEntityException("Data da movimentação de estoque é obrigatória.");

            if (stockLog.Qty == 0)
                throw new InvalidEntityException("A quantidade movimentada não pode ser zero.");
        }
    }
}
