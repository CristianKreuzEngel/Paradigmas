using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiWebDB.DTO;
using TrabalhoFinal.Services;

namespace ApiWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Controlador para gerenciar logs de estoque.
    /// </summary>
    public class StockLogsController : ControllerBase
    {
        private readonly StockLogService _stockLogService;

        public StockLogsController(StockLogService stockLogService)
        {
            _stockLogService = stockLogService;
        }
         /// <summary>
        /// Obtém logs de estoque por ID do produto.
        /// Retorna 200 se bem-sucedido.
        /// </summary>
        /// <param name="productId">ID do produto.</param>
        /// <returns>Lista de logs de estoque para o produto especificado.</returns>
        [HttpGet("product/{productId}")]
        public ActionResult<IEnumerable<StockLogDTO>> GetLogsByProduct(int productId)
        {
            var logs = _stockLogService.GetLogsByProduct(productId);
            return Ok(logs);
        }
    }
}
