using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using ApiWebDB.Services.Parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Controlador para gerenciar clientes.
    /// </summary>
    public class ClientesController : ControllerBase
    {
        public readonly ClienteService _service;
        public readonly ILogger<ClientesController> _logger;

        public ClientesController(ClienteService service, ILogger<ClientesController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Insere um novo cliente na base de dados.
        /// Retorna 200 se bem-sucedido, 422 para entidade inválida e 400 para requisição inválida.
        /// </summary>
        /// <param name="cliente">O DTO do cliente a ser inserido.</param>
        /// <returns>O cliente inserido, incluindo o ID gerado.</returns>
        [HttpPost()]
        public ActionResult<TbCliente> Insert(ClienteDTO cliente)
        {
            try
            {
                var entity = _service.Insert(cliente);
                return Ok(entity);
            }
            catch (InvalidEntityException E)
            {
                _logger.LogError(E.Message);
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 422
                };
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message);
            }
        }
        /// <summary>
        /// Atualiza um cliente na base de dados pelo ID.
        /// Retorna 200 se bem-sucedido e 400 para requisição inválida.
        /// </summary>
        /// <param name="id">O ID do cliente a ser atualizado.</param>
        /// <param name="dto">O DTO do cliente a ser atualizado.</param>
        /// <returns>O cliente atualizado, incluindo todos os seus campos.</returns>
        [HttpPut("{id}")]
        public ActionResult<TbCliente> Update(int id, ClienteDTO dto)
        {
            try
            {
                var entity = _service.Update(dto, id);
                return Ok(entity);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Deleta um cliente da base de dados pelo ID.
        /// Retorna 204 se bem-sucedido, 404 se o cliente não for encontrado e 500 para erro interno do servidor.
        /// </summary>
        /// <param name="id">O ID do cliente a ser deletado.</param>
        /// <returns>Retorna NoContent se o cliente for deletado com sucesso.</returns>
        [HttpDelete("{id}")]
        public ActionResult<TbCliente> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
        /// <summary>
        /// Obtém um cliente da base de dados pelo ID.
        /// Retorna 200 se bem-sucedido, 404 se o cliente não for encontrado e 500 para erro interno do servidor.
        /// </summary>
        /// <param name="id">O ID do cliente a ser obtido.</param>
        /// <returns>O cliente obtido, incluindo todos os seus campos.</returns>
        [HttpGet("{id}")]
        public ActionResult<TbCliente> GetById(int id)
        {
            try
            {
                var entity =  _service.GetById(id);
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
        /// <summary>
        /// Obtém todos os clientes da base de dados.
        /// Retorna 200 se bem-sucedido, 404 se nenhum cliente for encontrado e 500 para erro interno do servidor.
        /// </summary>
        /// <returns>Uma lista de todos os clientes, incluindo todos os seus campos.</returns>
        [HttpGet()]
        public ActionResult<TbCliente> Get()
        {
            try
            {
                var entity = _service.Get();
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
    }
}
