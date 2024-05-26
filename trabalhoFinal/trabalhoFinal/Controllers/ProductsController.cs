using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using trabalhoFinal.BaseDados.Models;
using trabalhoFinal.Services;
using System.Collections.Generic;

namespace trabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly ProductService _service;
        public readonly ILogger<ProductsController> _logger;

        public ProductsController(ProductService service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<TbProduct> GetById(int id)
        {
            try
            {
                var product = _service.getById(id);
                return Ok(product);
            }
            //catch(NotFoundException e)
            //{
            //    return NotFound(e.Message);
            //}
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
        [HttpPost()]
        public ActionResult<TbProduct> InsertProduct(TbProduct newProduct)
        {
            try
            {
                if (!_service.ValidateBarcode(newProduct.barcode))
                {
                    return BadRequest("Código de barras inválido.");
                }
                
                var product = _service.InsertProduct(newProduct);
                _service.LogStockChange(product.id, product.stock);
                return CreatedAtAction(nameof(GetById), new { id = product.id }, product);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Error inserting product");
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<TbProduct> EditProduct(int id, TbProduct updatedProduct)
        {
            try
            {
                var product = _service.UpdateProduct(id, updatedProduct);
                return Ok(product);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Error updating product");
                return StatusCode(500, new { error = e.Message });
            }
        }
        
        [HttpGet("barcode/{barcode}")]
        public ActionResult<TbProduct> GetByBarcode(string barcode)
        {
            try
            {
                var product = _service.GetByBarcode(barcode);
                return Ok(product);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Error fetching product by barcode");
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<TbProduct>> SearchProducts([FromQuery] string description)
        {
            try
            {
                var products = _service.SearchProducts(description);
                return Ok(products);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Error searching products");
                return StatusCode(500, new { error = e.Message });
            }
        }

        [HttpPatch("{id}/adjust-stock")]
        public ActionResult AdjustStock(int id, [FromQuery] int quantity)
        {
            try
            {
                _service.AdjustStock(id, quantity);
                _service.LogStockChange(id, quantity);
                return NoContent();
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Error adjusting stock");
                return StatusCode(500, new { error = e.Message });
            }
        }
    }

}

