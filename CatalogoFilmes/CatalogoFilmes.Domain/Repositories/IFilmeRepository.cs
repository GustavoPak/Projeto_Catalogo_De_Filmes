using CatalogoFilmes.Domain.Entities;
using CatalogoFilmes.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Domain.Repositories
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        Task RemoveMany(int[] vetor);
    }
}
