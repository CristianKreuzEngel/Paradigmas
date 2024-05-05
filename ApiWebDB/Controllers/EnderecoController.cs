using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Controlador para gerenciar endereços.
    /// </summary>
    public class EnderecoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly EnderecoService _service;
        public EnderecoController(EnderecoService service, ILogger<EnderecoController> logger)
        {
            _service = service;
            _logger = logger;
        }
        /// <summary>
        /// Insere um novo endereço na base de dados.
        /// Retorna 200 se bem-sucedido, 400 para requisição inválida e 422 para entidade inválida.
        /// </summary>
        /// <param name="endereco">O DTO do endereço a ser inserido. Este deve incluir todos os campos necessários para criar um novo endereço.</param>
        /// <returns>O endereço inserido, incluindo o ID gerado.</returns>
        [HttpPost]
        public ActionResult<TbEndereco> InsertAddress(EnderecoDTO endereco)
        {
            try
            {
                var entity = _service.InsertAddress(endereco);
                return Ok(entity);
            }
            catch (InvalidEntityException e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 422
                };
            }
            catch (BadRequestException e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 400
                };
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Obtém um endereço da base de dados pelo ID.
        /// Retorna 200 se bem-sucedido e 500 para erro interno do servidor.
        /// </summary>
        /// <param name="id">O ID do endereço a ser obtido. Este deve ser o ID de um endereço existente na base de dados.</param>
        /// <returns>O endereço obtido, incluindo todos os seus campos.</returns>
        [HttpGet("{id}")]
        public ActionResult<TbEndereco> GetAddress(int id)
        {
            try
            {
                var entity = _service.GetAddress(id);
                return Ok(entity);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
        /// <summary>
        /// Deleta um endereço da base de dados pelo ID.
        /// Retorna 204 se bem-sucedido, 404 se o endereço não for encontrado e 500 para erro interno do servidor.
        /// </summary>
        /// <param name="id">O ID do endereço a ser deletado. Este deve ser o ID de um endereço existente na base de dados.</param>
        /// <returns>Retorna NoContent se o endereço for deletado com sucesso.</returns>
        [HttpDelete("{id}")]
        public ActionResult<TbEndereco> DeleteAddress(int id)
        {
            try
            {
                _service.DeleteAddress(id);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return new ObjectResult(new { error = e.Message }) { StatusCode = 500 };

            }
        }
        /// <summary>
        /// Atualiza um endereço na base de dados pelo ID.
        /// Retorna 200 se bem-sucedido, 400 para requisição inválida, 404 se o endereço não for encontrado e 422 para entidade inválida.
        /// </summary>
        /// <param name="dto">O DTO do endereço a ser atualizado. Este deve incluir todos os campos que devem ser atualizados.</param>
        /// <param name="id">O ID do endereço a ser atualizado. Este deve ser o ID de um endereço existente na base de dados.</param>
        /// <returns>O endereço atualizado, incluindo todos os seus campos.</returns>
        [HttpPut("{id}")]
        public ActionResult<TbEndereco> UpdateAddress(EnderecoDTO dto, int id)
        {
            try
            {
                var entityAddress = _service.UpdateAddress(dto,id);
                return Ok(entityAddress);
            }
            catch (InvalidEntityException e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 422
                };
            }
            catch (BadRequestException e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 400
                };
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
 }
