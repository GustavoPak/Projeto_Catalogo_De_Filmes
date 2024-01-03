using AutoMapper;
using CatalogoFilmes.Application.DTO;
using CatalogoFilmes.Application.Interfaces;
using CatalogoFilmes.Application.Validators;
using CatalogoFilmes.Domain.Entities;
using CatalogoFilmes.Domain.Pagination;
using CatalogoFilmes.Domain.Repositories;
using CatalogoFilmes.Domain.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CatalogoFilmes.Application.Services
{
    public class FilmeService : ServiceBase,IFilmeService
    {
        
        private readonly FilmeValidator _validator;

        public FilmeService(IServiceProvider service, FilmeValidator validator) : base(service)
        {
            _validator = validator;
        }

        //public async Task AdicionarFilme(FilmeDTO filme)
        //{

        //    Filme destinFilme = _mapper.Map<Filme>(filme);

        //    if (_validator.Validate(destinFilme){
        //        return null;
        //    }

        //    await _uof.FilmeRepository.Add(destinFilme);
        //    await _uof.Commit();
        //}

        public async Task<Filme> AdicionarFilmee(FilmeDTO filme)
        {
            Filme destinFilme = _mapper.Map<Filme>(filme);

            if (_validator.Validate(destinFilme))
            {
                return null;
            }

            await _uof.FilmeRepository.Add(destinFilme);

            if (!await _uof.Committ())
            {
                Notify(EnumTipoNofication.ServerError, "Ocorreu um erro ao salvar os dados...");
                return null;
            }
            return destinFilme;
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

            if (filmes == null)
            {
                Notify(EnumTipoNofication.Informacao, "Nenhum filme encontrado...");
                return null;
            }

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
