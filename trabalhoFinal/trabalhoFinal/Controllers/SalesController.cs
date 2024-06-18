using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApiWebDB.DTO;
using TrabalhoFinal.Services;
using ApiWebDB.BaseDados.Models2;
using AutoMapper;

namespace ApiWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Controlador para gerenciar vendas.
    /// </summary>
    public class SalesController : ControllerBase
    {
        private readonly SaleService _saleService;
        private readonly IMapper _mapper;

        public SalesController(SaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtém uma venda pelo código.
        /// Retorna 200 se bem-sucedido e 404 se a venda não for encontrada.
        /// </summary>
        /// <param name="code">Código da venda.</param>
        /// <returns>O objeto da venda correspondente ao código.</returns>
        [HttpGet("{code}")]
        public ActionResult<SaleDTO> Get(string code)
        {
            return Ok(_saleService.GetByCode(code));
        }
        /// <summary>
        /// Adiciona uma nova venda.
        /// Retorna 201 se bem-sucedido, 400 para requisição inválida, 404 se um item não for encontrado, e 500 para erro interno do servidor.
        /// </summary>
        /// <param name="saleRequestDto">O objeto de requisição contendo a venda e os produtos.</param>
        /// <returns>As vendas inseridas.</returns>
        [HttpPost]
        public ActionResult<TbSale> Post([FromBody] SaleDTO dto)
        {
            var sale = _saleService.Insert(dto);
            if (sale == null)
                return BadRequest("Invalid sale data");
            return sale;
        }
        /// <summary>
        /// Obtém um relatório de vendas por período.
        /// Retorna 200 se bem-sucedido.
        /// </summary>
        /// <param name="code">Código da venda.</param>
        /// <param name="startDate">Data de início do período.</param>
        /// <param name="endDate">Data de término do período.</param>
        /// <returns>Relatório de vendas.</returns>
        [HttpGet("report")]
        public ActionResult<IEnumerable<SaleReportDTO>> GetSalesReportByPeriod([FromQuery] string code, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var report = _saleService.GetSalesReportByPeriod(code, startDate, endDate);
            return Ok(report);
        }
    }
}
