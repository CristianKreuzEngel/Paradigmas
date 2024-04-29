using ApiWebDB.BaseDados;
using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Parser;
using ApiWebDB.Services.validate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace ApiWebDB.Services
{
    public class ClienteService
    {
        private readonly ApiDbContext _dbContext;

        public ClienteService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TbCliente Insert(ClienteDTO dto)
        {
            Console.WriteLine(dto);
            if (!ClienteValidate.Execute(dto))
                return null;

            var entity = ClienteParser.ToEntity(dto);
            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }
        public TbCliente Update(TbCliente entity)
        {
            Console.WriteLine(entity);
            _dbContext.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }
            
        public TbCliente GetById(int id)
        {
            return _dbContext.TbClientes.FirstOrDefault(c => c.Id == id);
        }
    }
}
