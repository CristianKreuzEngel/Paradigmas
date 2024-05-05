using System;

namespace ApiWebDB.Services.DTOs
{
    public class EnderecoDTO
    {
        /// <example>
        /// 89870000
        /// </example>
        public int Cep { get; set; }
        /// <example>
        /// Rua Theobaldo Ross
        /// </example>
        public string Logradouro { get; set; }
        /// <example>
        /// 573
        /// </example>
        public string Numero { get; set; }
        /// <example>
        /// Casa
        /// </example>
        public string Complemento { get; set; }
        /// <example>
        /// Morada do Sol 3
        /// </example>
        public string Bairro { get; set; }
        /// <example>
        /// Saudades
        /// </example>
        public string Cidade { get; set; }
        /// <example>
        /// SC
        /// </example>
        public string Uf { get; set; }
        /// <example>
        /// 1
        /// </example>
        public int ClienteId { get; set; }
        /// <example>
        /// 1
        /// </example>
        public int Status { get; set; }
    }
}
