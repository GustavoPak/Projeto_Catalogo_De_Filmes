using CatalogoFilmes.Domain.Pagination;
using CatalogoFilmes.Domain.Repositories;
using CatalogoFilmes.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoFilmes.Infra.Data.Repositories
{
#nullable disable
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Entity entity)
        {
            await _context.Set<Entity>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<Entity>().FindAsync(id);

            _context.Set<Entity>().Remove(entity);
        }

        public async Task<IEnumerable<Entity>> GetAll(FilmeParameters filmeParams)
        {
            return await _context.Set<Entity>()
                .Skip((filmeParams.PageNumber - 1) * filmeParams.PageSize)
                .Take(filmeParams.PageSize)
                .ToListAsync();
        }

        public async Task<Entity> GetById(int id)
        {
            return await _context.Set<Entity>().FindAsync(id);
        }

        public void Update(Entity entity)
        {
            _context.Set<Entity>().Update(entity);
        }
    }
}
