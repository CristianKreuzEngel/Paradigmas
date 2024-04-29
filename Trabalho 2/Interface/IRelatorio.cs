using System.Collections.Generic;
using Trabalho_2.Classes;

namespace T2.Interfaces
{
	public interface IRelatorio
	{
		List<Produto> Imprimir(List<Produto> produtos);
	}
}
