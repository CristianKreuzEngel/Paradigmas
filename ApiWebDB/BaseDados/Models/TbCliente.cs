using System;
using System.Collections.Generic;

namespace ApiWebDB.BaseDados.Models;

public partial class TbCliente
{   public enum TipoDocumento
    {
        CPF = 1,
        CNPJ = 2,
        Passaporte = 3,
        CNH = 4,
        Outros = 99
    }

    public int Id { get; set; }

    public string Nome { get; set; }

    public DateTime? Nascimento { get; set; }

    public string Telefone { get; set; }

    public string Documento { get; set; }

    /// <summary>
    /// 1 - CPF, 2 - CNPJ, 3 - Passaporte, 4 - CNH, 99 - Outros
    /// </summary>
    public int Tipodoc { get; set; }

    public DateTime Criadoem { get; set; }

    public DateTime Alteradoem { get; set; }

    public virtual ICollection<TbEndereco> TbEnderecos { get; set; } = new List<TbEndereco>();
}
