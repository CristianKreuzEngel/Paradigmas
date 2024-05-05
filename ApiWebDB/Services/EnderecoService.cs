using ApiWebDB.BaseDados;
using ApiWebDB.BaseDados.Models;
using ApiWebDB.Controllers;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using ApiWebDB.Services.Parser;
using ApiWebDB.Services.Validate;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ApiWebDB.Services
{
    public class EnderecoService
    {
        private readonly ApiDbContext _dbContext;
        private readonly ILogger _logger;

        public EnderecoService(ApiDbContext dbcontext, ILogger<ClientesController> logger)
        {
            _dbContext = dbcontext;
            _logger = logger;
        }

        public TbEndereco InsertAddress(EnderecoDTO dto)
        {
            if(!EnderecoValidate.Execute(dto)) return null;

            var entity = EnderecoParser.ToEntity(dto);

            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public TbEndereco GetAddress(int id)
        {
            var existingEntity = _dbContext.TbEnderecos.FirstOrDefault(Address => Address.Clienteid == id);
            return existingEntity;
        }

        public TbEndereco GetAddressById(int id)
        {
            var existingEntity = _dbContext.TbEnderecos.FirstOrDefault(Address => Address.Id == id);
            if(existingEntity == null)
            {
                throw new NotFoundException("Endereço não existe");
            }
            return existingEntity;
        }
        public void DeleteAddress(int id)
        {
            var existingEntity = GetAddressById(id);
            if (existingEntity == null)
            {
                throw new NotFoundException("Endereço não existe");
            }
            _dbContext.Remove(existingEntity);
            _dbContext.SaveChanges();
        }
        public TbEndereco UpdateAddress(EnderecoDTO dto, int id)
        {
            var existingEntity = GetAddressById(id);
            if (existingEntity == null)
            {
                throw new NotFoundException("Endereço não existe");
            }

            if (!EnderecoValidate.Execute(dto)) return null;

            var entity = EnderecoParser.ToEntity(dto);
            existingEntity.Logradouro = entity.Logradouro;
            existingEntity.Numero = entity.Numero;
            existingEntity.Cidade = entity.Cidade;
            existingEntity.Uf = entity.Uf;
            existingEntity.Status = entity.Status;
            existingEntity.Bairro = entity.Bairro;
            existingEntity.Cep = entity.Cep;

            _dbContext.Update(existingEntity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
