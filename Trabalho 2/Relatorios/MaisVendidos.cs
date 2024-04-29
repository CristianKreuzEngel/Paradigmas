using System;
using System.Collections.Generic;
using System.Linq;
using Trabalho_2.Classes;
using T2.Interfaces;


namespace Trabalho_2.Relatorios
{
    public class MaisVendidos : IRelatorio
    {
        public List<Produto> Imprimir(List<Produto> produtos)
        {
            return produtos.OrderByDescending(p => p.QtdVendida).Take(5).ToList();
            
        }
    }
}
