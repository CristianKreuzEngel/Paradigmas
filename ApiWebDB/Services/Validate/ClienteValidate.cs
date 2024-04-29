using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using static ApiWebDB.BaseDados.Models.TbCliente;

namespace ApiWebDB.Services.validate
{
    public class ClienteValidate
    {
        private static bool ValidateDocument(TipoDocumento tipo, string document)
        {
            switch (tipo)
            {
                case TipoDocumento.CPF:
                    if (document.Length != 11)
                        throw new BadRequestException("O CPF precisa ter 11 digitos");
                    return true;
                case TipoDocumento.CNPJ:
                    if (document.Length != 14)
                        throw new BadRequestException("O CNPJ precisa ter 14 digitos");
                    return true;
                case TipoDocumento.Passaporte:
                    if (document.Length != 8)
                        throw new BadRequestException("O Passaporte precisa ter 8 digitos");
                    return true;
                case TipoDocumento.CNH:
                    if (document.Length != 11)
                        throw new BadRequestException("O CNH precisa ter 11 digitos");
                    return true;
                default:
                    return true;
            }
        }
        public static bool Execute(ClienteDTO dto)
            {
            if (string.IsNullOrEmpty(dto.Nome))
            {
                throw new InvalidEntityException("Campo Nome é obrigatório");
            }
            if(string.IsNullOrEmpty(dto.Documento))
            {
                throw new InvalidEntityException("Campo Documento é obrigatório");
            }
            if (dto.Tipodoc <= 0)
                throw new InvalidEntityException("Campo TipoDoc é obrigatório");
            TipoDocumento tipo;
            try
            {
                tipo = (TipoDocumento)dto.Tipodoc;
            }
            catch
            {
                throw new InvalidEntityException($"O TipoDoc {dto.Tipodoc} é inválido.");
            }
            return ValidateDocument( tipo, dto.Documento );
        }
    }
}