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
    public class SalesController : ControllerBase
    {
        private readonly SaleService _saleService;
        private readonly IMapper _mapper;

        public SalesController(SaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        [HttpGet("{code}")]
        public ActionResult<SaleDTO> Get(string code)
        {
            return Ok(_saleService.GetByCode(code));
        }

        [HttpPost]
        public ActionResult<TbSale> Post([FromBody] SaleDTO dto)
        {
            var sale = _saleService.Insert(dto);
            if (sale == null)
                return BadRequest("Invalid sale data");
            return sale;
        }

        [HttpGet("report")]
        public ActionResult<IEnumerable<SaleReportDTO>> GetSalesReportByPeriod([FromQuery] string code, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var report = _saleService.GetSalesReportByPeriod(code, startDate, endDate);
            return Ok(report);
        }
    }
}
