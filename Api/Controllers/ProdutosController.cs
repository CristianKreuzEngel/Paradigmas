using Api.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(
        MediaTypeNames.Application.Json,
        MediaTypeNames.Application.Xml)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;
        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet()]
        public ActionResult<List<Produto>> GetAll()
        {
            return Ok(_produtoService.GetAll());
        }

        [HttpGet(":codigo")]
        public ActionResult<Produto> GetByCodigo(int codigo)
        {
            try
            {
                var produto = _produtoService.GetById(codigo);

                return Ok(produto);
            }
            catch (NotFoundException)
            {
                return NotFound("Produto Não Encontrado. ");
            }
            catch (Exception e)
            {
                return BadRequest(
                    "Ocorreu um problema ao acessar produto." + 
                    e.Message);
            }
        }
    }
}