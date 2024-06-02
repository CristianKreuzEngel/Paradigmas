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
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(ProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

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

        [HttpPost]
        public ActionResult<TbProduct> Post([FromBody] ProductDTO dto)
        {
            var product = _productService.Insert(dto);
            if (product == null)
                return BadRequest("Invalid product data");
            return Ok(_mapper.Map<ProductDTO>(product));
        }

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
