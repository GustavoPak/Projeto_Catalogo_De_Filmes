using CatalogoFilmes.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Domain.Repositories
{
    public interface IRepository<Entity>
    {
        Task<IEnumerable<Entity>> GetAll(FilmeParameters filmeParams);
        Task<Entity> GetById(int id);
        Task Add(Entity entity);
        void Update(Entity entity);
        Task Delete(int id);
    }
}
