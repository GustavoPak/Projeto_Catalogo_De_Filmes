using CatalogoFilmes.Application.DTO;
using CatalogoFilmes.Domain.Entities;
using CatalogoFilmes.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Application.Interfaces
{
    public interface IFilmeService
    {
        Task<IEnumerable<FilmeDTO>> ObterFilmes(FilmeParameters filmeParameters);
        Task<FilmeDTO> ObterFilmeDetalhe(int id);
        //Task AdicionarFilme(FilmeDTO filme);
        Task AtualizarFilme(FilmeDTO filme);
        Task RemoverFilme(int id);
        Task RemoverFilmes(int[] ids);
        Task<Filme> AdicionarFilmee(FilmeDTO filme);
    }
}
