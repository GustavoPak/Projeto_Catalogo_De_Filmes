using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CatalogoFilmes.Application.DTO;
using CatalogoFilmes.Application.Interfaces;
using System.Globalization;
using CatalogoFilmes.Domain.Pagination;
using System.Net;
using CatalogoFilmes.Domain.Entities;

namespace CatalogoFilmes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : BaseController
    {
        private IFilmeService _filmeService;

        public FilmesController(IFilmeService filmeService, IServiceProvider service) : base(service)
        {
            _filmeService = filmeService;
        }

        /// <summary>
        /// Obtem Filmes filtrados por páginas
        /// </summary>
        /// <param name="filmesParameters">Parametros do filme(Query)</param>
        /// <returns>Objeto Filme</returns>

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilmeParameters filmesParameters)
        {
            var filmes = await _filmeService.ObterFilmes(filmesParameters);

            if (filmes == null)
            {
                return CustomResponse();
            }

            return Ok(filmes);
        }

        /// <summary>
        /// Obtem uma categoria pelo seu Id
        /// </summary>
        /// <param name="id"> Forneça o Id do filme</param>
        /// <returns>Objeto Filme</returns>

        [HttpGet("{id:int}", Name = "GetMovie")]
        public async Task<IActionResult> GetById(int id)
        {
            var filme = await _filmeService.ObterFilmeDetalhe(id);

            if (filme == null)
            {
                return NotFound("Filme inexistente no banco de dados...");
            }

            return Ok(filme);
        }

        /// <summary>
        ///  Inclui uma nova categoria
        /// </summary>
        /// <remarks>
        /// Exemplo de Request:
        /// 
        ///       POST api/Filmes
        ///       {
        ///         "Titulo" : "BladeRunners",
        ///         "Descricao" : "Filme de ação",
        ///         "Autor" : "Paulo Mikael",
        ///         "Lancamento" : "03-02-2001"
        ///       }
        /// </remarks>
        /// <param name="filmeDto"></param>
        /// <returns>Retorna um objeto FilmeDTO</returns>

        [HttpPost]
        public async Task<IActionResult> Post(FilmeDTO filmeDto)
        {
           

            if (filmeDto == null) return BadRequest("Valores não fornecidos");

            var filme = await _filmeService.AdicionarFilmee(filmeDto);

            var teste = "Esse é um teste inutil";

            if (filme == null) return CustomResponse();

            return Ok(filme);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(FilmeDTO filmeDto)
        //{
        //    if (filmeDto == null)
        //    {
        //        return BadRequest("Valores não fornecidos");
        //    }

        //    await _filmeService.AdicionarFilme(filmeDto);

        //    return new CreatedAtRouteResult("GetMovie", new { Id = filmeDto.Id }, filmeDto);
        //}

        /// <summary>
        /// Remove vários filmes do catálogo
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///        POST /Filmes/DeletarVarios    
        ///        {
        ///          "Array" : [1,2,3]
        ///        } 
        /// </remarks>
        /// <param name="arrayremove">Id do filme</param>
        /// <returns>Retorna o codigo 201(Concluido)</returns>

        [HttpPost("/Filmes/DeletarVarios")]
        public async Task<IActionResult> Deletemany(ArrayRemoveDTO arrayremove)
        {
            if(arrayremove == null)
            {
                return BadRequest();
            }

            await _filmeService.RemoverFilmes(arrayremove.Array);

            return Ok();
        }

        /// <summary>
        /// Atualiza o Filme Selecionado
        /// </summary>
        /// <remarks>
        /// Exemplo de Request:
        /// 
        ///       PUT api/Filmes
        ///       {
        ///         "Titulo" : "BladeRunners",
        ///         "Descricao" : "Filme de ação",
        ///         "Autor" : "Paulo Mikael",
        ///         "Lancamento" : "03-02-2001"
        ///       }
        /// </remarks>
        /// <returns>Objeto Filme</returns> 

        [HttpPut]
        public async Task<IActionResult> Put(int id,FilmeDTO filme)
        {

            throw new Exception();

            if (filme == null)
            {
                return BadRequest("Valores não recebidos do objeto...");
            }
            else if (id != filme.Id)
            {
                return BadRequest("Erro no envio! Id precisa corresponder ao Id do objeto!");
            }

            await _filmeService.AtualizarFilme(filme);

            return Ok(filme);
        }

        /// <summary>
        /// Deleta um filme do catalogo
        /// </summary>
        /// <param name="id">Id do filme</param>
        /// <returns>Retorna o codigo 200(Ok)</returns>

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            FilmeDTO filme = await _filmeService.ObterFilmeDetalhe(id);

            if(filme == null)
            {
                return BadRequest("Filme não encontrado no banco de dados...");
            }

            await _filmeService.RemoverFilme(id);

            return Ok();
        }
    }
}
