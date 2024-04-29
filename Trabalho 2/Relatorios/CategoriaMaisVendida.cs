/*using System;
using System.Collections.Generic;
using System.Linq;
using Trabalho_2.Classes;
using T2.Interfaces;

namespace Trabalho_2.Relatorios
{
    public class CategoriaMaisVendida : IRelatorio
    {
        public void Imprimir(List<Produto> produtos)
        {
            return produtos.GroupBy(p => p.Categoria)
                                    .OrderByDescending(g => g.Sum(p => p.QtdVendida))
                                    .First()
                                    .Key;
            Console.WriteLine($"Categoria mais vendida: {categoria}");
            Console.WriteLine();
        }
    }
}
*/