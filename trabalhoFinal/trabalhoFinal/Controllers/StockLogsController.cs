using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiWebDB.DTO;
using TrabalhoFinal.Services;

namespace ApiWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockLogsController : ControllerBase
    {
        private readonly StockLogService _stockLogService;

        public StockLogsController(StockLogService stockLogService)
        {
            _stockLogService = stockLogService;
        }

        [HttpGet("product/{productId}")]
        public ActionResult<IEnumerable<StockLogDTO>> GetLogsByProduct(int productId)
        {
            var logs = _stockLogService.GetLogsByProduct(productId);
            return Ok(logs);
        }
    }
}
