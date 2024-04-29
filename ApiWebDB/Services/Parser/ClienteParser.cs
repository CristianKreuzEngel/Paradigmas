using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;
using Microsoft.AspNetCore.Routing.Constraints;
using System;

namespace ApiWebDB.Services.Parser
{
    public class ClienteParser
    {
        public static TbCliente ToEntity(ClienteDTO dto)
        {
            var time = new TimeOnly(0, 0);
            var nascimento = new DateTime(
                (DateOnly)dto.Nascimento, time);

            return new TbCliente
            {
                Nascimento = nascimento,
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Tipodoc = dto.Tipodoc,
                Documento = dto.Documento,
                Criadoem = System.DateTime.Now,
                Alteradoem = System.DateTime.Now,
            };
        }
        public static void UpdateEntityFromDTO(ClienteDTO dto, TbCliente entity)
        {
            var time = new TimeOnly(0, 0);
            var nascimento = new DateTime(
                (DateOnly)dto.Nascimento, time);

            entity.Nome = dto.Nome;
            entity.Nascimento = nascimento;
            entity.Telefone = dto.Telefone;
            entity.Tipodoc = dto.Tipodoc;
            entity.Documento = dto.Documento;
            entity.Alteradoem = DateTime.Now;
        }
    }
}

