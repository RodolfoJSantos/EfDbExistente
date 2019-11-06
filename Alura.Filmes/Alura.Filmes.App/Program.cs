using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

				var filme = contexto.Filmes
					.Include(f => f.Atores)
					.First();

				Console.WriteLine(filme);

				foreach (var ator in filme.Atores)
				{
					Console.WriteLine(ator);
				}
            }
        }
    }
}