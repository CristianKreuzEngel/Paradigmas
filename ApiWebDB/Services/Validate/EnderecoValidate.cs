using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Exceptions;
using System.Collections.Generic;

namespace ApiWebDB.Services.Validate
{
    public class EnderecoValidate
    {
        private static HashSet<string> ValidUFs = new HashSet<string> { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };

        public static bool ValidateUF(string uf)
        {
            if (!ValidUFs.Contains(uf.ToUpper()))
                throw new BadRequestException("UF inválida, informe uma UF do Brasil");
            return true;
        }

        private static void ValidateRequiredFields(EnderecoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Logradouro))
                throw new InvalidEntityException("Campo Logradouro é obrigatório");
            if (string.IsNullOrEmpty(dto.Numero))
                throw new InvalidEntityException("Campo Numero é obrigatório");
            if (string.IsNullOrEmpty(dto.Bairro))
                throw new InvalidEntityException("Campo Bairro é obrigatório");
            if (string.IsNullOrEmpty(dto.Cidade))
                throw new InvalidEntityException("Campo Cidade é obrigatório");
            if (string.IsNullOrEmpty(dto.Uf))
                throw new InvalidEntityException("Campo Uf é obrigatório");
            if (dto.ClienteId <= 0)
                throw new InvalidEntityException("Campo Cliente não pode ser nulo");
            if (dto.Cep <= 0)
                throw new InvalidEntityException("Campo Cep não pode ser nulo");
        }
        private static void ValidateNumericFields(EnderecoDTO dto)
        {
            if (dto.Cep.ToString().Length != 8)
                throw new BadRequestException("Tamanho do CEP não pode exceder 8 caracteres");
        }

        private static void ValidateStringLength(EnderecoDTO dto)
        {
            if (dto.Logradouro.Length > 255)
                throw new BadRequestException("Tamanho do Logradouro não pode exceder 255 caracteres");
            if (dto.Numero.Length > 20)
                throw new BadRequestException("Tamanho do Numero não pode exceder 255 caracteres");
            if (dto.Bairro.Length > 100)
                throw new BadRequestException("Tamanho do Bairro não pode exceder 255 caracteres");
            if (dto.Cidade.Length > 255)
                throw new BadRequestException("Tamanho do Cidade não pode exceder 255 caracteres");
            if (dto.Complemento.Length > 255)
                throw new BadRequestException("Tamanho do Cidade não pode exceder 255 caracteres");
        }

        private static void ValidateStatus(int status)
        {
            if (status != 0 && status != 1)
                throw new BadRequestException("Status deve ser 0 ou 1. Verifique!");
        }

        public static bool Execute(EnderecoDTO dto)
        {
            ValidateRequiredFields(dto);
            ValidateNumericFields(dto);
            ValidateStringLength(dto);
            ValidateStatus(dto.Status);
            return ValidateUF(dto.Uf);
        }
    }
}