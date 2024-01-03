using CatalogoFilmes.Domain.Repositories;
using CatalogoFilmes.Infra.Data.Context;

namespace CatalogoFilmes.Infra.Data.Repositories
{
   #nullable disable
    public class UnitOfWork : IUnitOfWork
    {
        private FilmeRepository _filmeRepo;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IFilmeRepository FilmeRepository
        {
            get
            {
                return _filmeRepo = _filmeRepo ?? new FilmeRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Committ() => await _context.SaveChangesAsync() > 0;

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
