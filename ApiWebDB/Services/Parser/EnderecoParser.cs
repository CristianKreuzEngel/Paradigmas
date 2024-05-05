using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;

namespace ApiWebDB.Services.Parser
{
    public class EnderecoParser
    {
        public static TbEndereco ToEntity(EnderecoDTO dto)
        {

            return new TbEndereco
            {
                Cidade = dto.Cidade,
                Cep = dto.Cep,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,  
                Bairro  = dto.Bairro,
                Uf = dto.Uf,
                Clienteid = dto.ClienteId,
                Status = dto.Status,
            };

        }
    }
}
