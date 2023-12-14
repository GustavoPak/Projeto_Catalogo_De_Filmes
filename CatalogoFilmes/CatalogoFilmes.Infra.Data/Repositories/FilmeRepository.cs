using CatalogoFilmes.Domain.Entities;
using CatalogoFilmes.Domain.Repositories;
using CatalogoFilmes.Infra.Data.Context;

namespace CatalogoFilmes.Infra.Data.Repositories
{
#nullable disable
    public class FilmeRepository : Repository<Filme>,IFilmeRepository
    {
        public FilmeRepository(AppDbContext context) : base(context) { }

        public async Task RemoveMany(int[] vetor)
        {
            List<Filme> filmes = new List<Filme>();

            foreach (int obj in vetor)
            {
                filmes.Add(await _context.Filmes.FindAsync(obj));
            }

            _context.Filmes.RemoveRange(filmes);
        }
    }
}
