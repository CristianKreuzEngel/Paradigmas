using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiWebDB.DTO;
using TrabalhoFinal.Services;
using ApiWebDB.Services.Exceptions;
using ApiWebDB.BaseDados.Models2;
using AutoMapper;


namespace ApiWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Controlador para gerenciar produtos.
    /// </summary>
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(ProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtém um produto pelo código de barras.
        /// Retorna 200 se bem-sucedido e 404 se o produto não for encontrado.
        /// </summary>
        /// <param name="barcode">Código de barras do produto.</param>
        /// <returns>O produto correspondente ao código de barras.</returns>
        [HttpGet("barcode/{barcode}")]
        public ActionResult<TbProduct> GetByBarcode(string barcode)
        {
            try
            {
                var entity = _productService.GetByBarcode(barcode);
                return Ok(_mapper.Map<ProductDTO>(entity));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Obtém produtos pela descrição.
        /// Retorna 200 se bem-sucedido e 404 se nenhum produto for encontrado.
        /// </summary>
        /// <param name="description">Descrição do produto.</param>
        /// <returns>Lista de produtos que correspondem à descrição.</returns>
        [HttpGet("description/{description}")]
        public ActionResult<IEnumerable<TbProduct>> GetByDescription(string description)
        {
            try
            {
                var entity = _productService.GetByDescription(description);
                return Ok(_mapper.Map<IEnumerable<ProductDTO>>(entity));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Adiciona um novo produto.
        /// Retorna 200 se bem-sucedido, 400 para requisição inválida.
        /// </summary>
        /// <param name="product">O objeto do produto a ser inserido.</param>
        /// <returns>O produto inserido.</returns>
        [HttpPost]
        public ActionResult<TbProduct> Post([FromBody] ProductDTO dto)
        {
            var product = _productService.Insert(dto);
            if (product == null)
                return BadRequest("Invalid product data");
            return Ok(_mapper.Map<ProductDTO>(product));
        }
        /// <summary>
        /// Atualiza um produto existente.
        /// Retorna 204 se bem-sucedido, 400 para requisição inválida e 404 se o produto não for encontrado.
        /// </summary>
        /// <param name="id">ID do produto a ser atualizado.</param>
        /// <param name="product">O objeto do produto atualizado.</param>
        /// <returns>O produto atualizado.</returns>
        [HttpPut("{id}")]
        public ActionResult<TbProduct> Put(int id, [FromBody] ProductDTO dto)
        {
            try
            {
                var product = _productService.Update(dto, id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        /// <summary>
        /// Ajusta o estoque de um produto.
        /// Retorna 204 se bem-sucedido e 404 se o produto não for encontrado.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <param name="quantity">Quantidade a ser ajustada.</param>
        /// <returns>Resultado da operação.</returns>
        [HttpPatch("{id}/adjust-stock")]
        public ActionResult AdjustStock(int id, [FromBody] int quantity)
        {
            try
            {
                _productService.AdjustStock(id, quantity);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
