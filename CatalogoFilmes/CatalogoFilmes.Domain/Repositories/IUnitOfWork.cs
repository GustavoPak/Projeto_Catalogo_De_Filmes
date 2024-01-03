using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IFilmeRepository FilmeRepository { get; }

        Task Commit();

        Task<bool> Committ();
    }
}
