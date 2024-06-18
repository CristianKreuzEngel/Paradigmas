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
     /// <summary>
    /// Controlador para gerenciar promoções.
    /// </summary>
    public class PromotionsController : ControllerBase
    {
        private readonly PromotionService _promotionService;
        private readonly IMapper _mapper;

        public PromotionsController(PromotionService promotionService, IMapper mapper)
        {
            _promotionService = promotionService;
            _mapper = mapper;
            
        }
        /// <summary>
        /// Obtém promoções por produto e período.
        /// Retorna 200 se bem-sucedido e 404 se nenhuma promoção for encontrada.
        /// </summary>
        /// <param name="productId">ID do produto.</param>
        /// <param name="startDate">Data de início do período.</param>
        /// <param name="endDate">Data de término do período.</param>
        /// <returns>Lista de promoções.</returns>
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
        /// <summary>
        /// Adiciona uma nova promoção.
        /// Retorna 200 se bem-sucedido, 400 para requisição inválida.
        /// </summary>
        /// <param name="dto">O objeto da promoção a ser inserida.</param>
        /// <returns>A promoção inserida.</returns>
        [HttpPost]
        public ActionResult<TbPromotion> Post([FromBody] PromotionDTO dto)
        {
            var promotion = _promotionService.Insert(dto);
            if (promotion == null)
                return BadRequest("Promoção inválida");

            return Ok(_mapper.Map<PromotionDTO>(promotion));
        }
        /// <summary>
        /// Atualiza uma promoção existente.
        /// Retorna 204 se bem-sucedido, 400 para requisição inválida e 404 se a promoção não for encontrada.
        /// </summary>
        /// <param name="id">ID da promoção a ser atualizada.</param>
        /// <param name="dto">O objeto da promoção atualizada.</param>
        /// <returns>Resultado da operação.</returns>
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
