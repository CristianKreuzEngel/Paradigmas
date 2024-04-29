using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trabalho_2.Classes;


            var dataset = File.ReadAllText("..\\..\\..\\dataset.csv");
            var list = ProdutoParser.ConverterLista(dataset);

            int opcao;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Produtos mais vendidos");
                Console.WriteLine("2) Produtos com mais estoque");
                Console.WriteLine("3) Categoria mais vendida");
                Console.WriteLine("4) Produtos menos vendidos");
                Console.WriteLine("5) Estoque de segurança");
                Console.WriteLine("6) Excesso de estoque");
                Console.WriteLine("7) Média de preço por categoria");
                Console.WriteLine("0) sair do programa");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ProdutosMaisVendidos(list);
                        break;
                    case 2:
                        ProdutosComMaisEstoque(list);
                        break;
                    case 3:
                        CategoriaMaisVendida(list);
                        break;
                    case 4:
                        ProdutosMenosVendidos(list);
                        break;
                    case 5:
                        EstoqueSeguranca(list);
                        break;
                    case 6:
                        ExcessoEstoque(list);
                        break;
                    case 7:
                        MediaPrecoCategoria(list);
                        break;
                    case 0:
                        Console.WriteLine("Saindo");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 0);
        

        static void ProdutosMaisVendidos(List<Produto> produtos)
        {
            var a = produtos.OrderByDescending(p => p.QtdVendida).Take(5);
            Console.WriteLine("Produtos mais vendidos:");
            foreach (var produto in a)
            {
                Console.WriteLine($"{produto.Codigo} - {produto.Descricao}");
            }
            Console.WriteLine();
        }

        static void ProdutosComMaisEstoque(List<Produto> produtos)
        {
            var b = produtos.OrderByDescending(p => p.Estoque).Take(3);
            Console.WriteLine("Produtos com mais estoque:");
            foreach (var produto in b)
            {
                Console.WriteLine($"{produto.Codigo} - {produto.Descricao}: {produto.Estoque}");
            }
            Console.WriteLine();
        }

        static void CategoriaMaisVendida(List<Produto> produtos)
        {
            var categoria = produtos.GroupBy(p => p.Categoria)
                                    .OrderByDescending(g => g.Sum(p => p.QtdVendida))
                                    .First()
                                    .Key;
            Console.WriteLine($"Categoria mais vendida: {categoria}");
            Console.WriteLine();
        }

        static void ProdutosMenosVendidos(List<Produto> produtos)
        {
            var c = produtos.OrderBy(p => p.QtdVendida).Take(5);
            Console.WriteLine("Produtos menos vendidos:");
            foreach (var produto in c)
            {
                Console.WriteLine($"{produto.Codigo} - {produto.Descricao}: {produto.QtdVendida}");
            }
            Console.WriteLine();
        }

        static void EstoqueSeguranca(List<Produto> produtos)
        {
            var estoqueSeguranca = produtos.Where(p => p.Estoque < p.QtdVendida * 0.33);
            Console.WriteLine("Estoque de segurança:");
            foreach (var produto in estoqueSeguranca)
            {
                Console.WriteLine($"{produto.Codigo} - {produto.Descricao}: {produto.Estoque}");
            }
            Console.WriteLine();
        }

        static void ExcessoEstoque(List<Produto> produtos)
        {
            var excessoEstoque = produtos.Where(p => p.Estoque >= p.QtdVendida * 3);
            Console.WriteLine("Excesso de estoque:");
            foreach (var produto in excessoEstoque)
            {
                Console.WriteLine($"{produto.Codigo} - {produto.Descricao}: {produto.Estoque}");
            }
            Console.WriteLine();
        }

        static void MediaPrecoCategoria(List<Produto> produtos)
        {
            var mediaPrecoPorCategoria = produtos.GroupBy(p => p.Categoria)
                                                 .Select(g => new
                                                 {
                                                     Categoria = g.Key,
                                                     PrecoMedio = g.Average(p => p.Preco)
                                                 });
            Console.WriteLine("Média de preço por categoria:");
            foreach (var item in mediaPrecoPorCategoria)
            {
                Console.WriteLine($"{item.Categoria}: {item.PrecoMedio:C}");
            }
            Console.WriteLine();
        }
    

