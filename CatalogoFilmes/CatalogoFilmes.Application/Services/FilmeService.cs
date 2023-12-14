using AutoMapper;
using CatalogoFilmes.Application.DTO;
using CatalogoFilmes.Application.Interfaces;
using CatalogoFilmes.Domain.Entities;
using CatalogoFilmes.Domain.Pagination;
using CatalogoFilmes.Domain.Repositories;

namespace CatalogoFilmes.Application.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public FilmeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uof = unitOfWork;
            _mapper = mapper;
        }

        public async Task AdicionarFilme(FilmeDTO filme)
        {
            Filme destinFilme = _mapper.Map<Filme>(filme);

            await _uof.FilmeRepository.Add(destinFilme);
            await _uof.Commit();
        }

        public async Task AtualizarFilme(FilmeDTO filme)
        {
            Filme destinFilme = _mapper.Map<Filme>(filme);

             _uof.FilmeRepository.Update(destinFilme);
            await _uof.Commit();
        }

        public async Task<FilmeDTO> ObterFilmeDetalhe(int id)
        {
            Filme filmeSource = await _uof.FilmeRepository.GetById(id);

            FilmeDTO filmeDto = _mapper.Map<FilmeDTO>(filmeSource);

            return filmeDto;
        }

        public async Task<IEnumerable<FilmeDTO>> ObterFilmes(FilmeParameters filmeParameters)
        {
            IEnumerable<Filme> filmes = await _uof.FilmeRepository.GetAll(filmeParameters);

            IEnumerable<FilmeDTO> filmesDto = _mapper.Map<IEnumerable<FilmeDTO>>(filmes);

            return filmesDto;
        }

        public async Task RemoverFilme(int id)
        {
            await _uof.FilmeRepository.Delete(id);
            await _uof.Commit();
        }

        public async Task RemoverFilmes(int[] ids)
        {
            await _uof.FilmeRepository.RemoveMany(ids);
            await _uof.Commit();
        }
    }
}
