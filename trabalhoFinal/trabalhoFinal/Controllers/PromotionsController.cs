using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ApiWebDB.DTO;
using TrabalhoFinal.Services;
using ApiWebDB.BaseDados.Models2;
using ApiWebDB.Services.Exceptions;
using AutoMapper;

namespace ApiWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly PromotionService _promotionService;
        private readonly IMapper _mapper;

        public PromotionsController(PromotionService promotionService, IMapper mapper)
        {
            _promotionService = promotionService;
            _mapper = mapper;
            
        }

        [HttpGet("product/{productId}/period")]
        public ActionResult<IEnumerable<TbPromotion>> GetPromotionsByProductAndPeriod(int productId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var promotion = _promotionService.GetPromotionsByProductAndPeriod(productId, startDate, endDate);
                return Ok(promotion);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<TbPromotion> Post([FromBody] PromotionDTO dto)
        {
            var promotion = _promotionService.Insert(dto);
            if (promotion == null)
                return BadRequest("Invalid promotion data");

            return Ok(_mapper.Map<PromotionDTO>(promotion));
        }

        [HttpPut("{id}")]
        public ActionResult<TbPromotion> Put(int id, [FromBody] PromotionDTO dto)
        {
            try
            {
                var promotion = _promotionService.Update(dto, id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
