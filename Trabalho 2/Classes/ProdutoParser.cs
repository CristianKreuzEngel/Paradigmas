using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Trabalho_2.Classes
{
    public enum Header
    {
        Codigo = 0,
        Descricao = 1,
        Categoria = 2,
        Preco = 3,
        Estoque = 4,
        QtdVendida = 5
    }

    public class ProdutoParser
    {
        public static List<Produto> ConverterLista(string arquivo)
        {
            List<Produto> produtos = new();

            var linhas = arquivo.Split('\n').ToList();

            linhas.Remove(linhas.First());

            foreach (var linha in linhas)
            {
                Produto produto = new()
                {
                    Codigo = Convert.ToInt32(
                        linha.Split(';')[(int)Header.Codigo]),
                    Descricao = linha.Split(";")[(int)Header.Descricao],
                    Categoria = linha.Split(";")[(int)Header.Categoria],
                    Preco = Convert.ToDouble(
                        linha.Split(";")[(int)Header.Preco], CultureInfo.InvariantCulture),
                    Estoque = Convert.ToInt32(
                        linha.Split(';')[(int)Header.Estoque]),
                    QtdVendida = Convert.ToInt32(
                        linha.Split(';')[(int)Header.QtdVendida]),
                };
                produtos.Add(produto);
            }

            return produtos;
        }
    }
}

