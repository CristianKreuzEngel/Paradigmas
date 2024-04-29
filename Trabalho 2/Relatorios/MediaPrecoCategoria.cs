/*
 * using System;
using System.Collections.Generic;
using System.Linq;
using Trabalho_2.Classes;
using T2.Interfaces;

namespace Trabalho_2.Relatorios
{
    public class MediaPrecoCategoria : IRelatorio
    {
        public List<Produto> Imprimir(List<Produto> produtos)
        {
            return produtos.GroupBy(p => p.Categoria)
                                                .Select(g => new
                                                {
                                                    Categoria = g.Key,
                                                    PrecoMedio = g.Average(p => p.Preco)
                                                });
            
        }
    }
} */