using System;

namespace ApiWebDB.Services.DTOs
{
    public class ClienteDTO
    {
        public string Nome { get; set; }

        public DateOnly? Nascimento { get; set; }

        public string Telefone { get; set; }

        public string Documento { get; set; }

        public int Tipodoc { get; set; }
    }
}
