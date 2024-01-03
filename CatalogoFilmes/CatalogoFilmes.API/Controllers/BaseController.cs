using CatalogoFilmes.Application.Interfaces;
using CatalogoFilmes.Domain.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoFilmes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly INotificator _notificador;

        public BaseController(IServiceProvider service)
        {
            _notificador = service.GetRequiredService<INotificator>();
        }

        protected IActionResult CustomResponse()
        {
            if (_notificador.ListNotificacoes.Count > 0)
            {
                var erros = _notificador.ListNotificacoes.Where(item => item.StatusCode == EnumTipoNofication.ClientError);
                if (erros.Any())
                {
                    var result = new { Mensagens = erros.ToArray() };
                    return BadRequest(result);
                }

                var errosInternos = _notificador.ListNotificacoes.Where(item => item.StatusCode == EnumTipoNofication.ServerError);
                if (errosInternos.Any())
                {
                    var result = new { Mensagens = errosInternos.ToArray() };
                    return new ObjectResult(result) { StatusCode = 500 };
                }

                var informacoes = _notificador.ListNotificacoes.Where(item => item.StatusCode == EnumTipoNofication.Informacao);
                if (informacoes.Any())
                    return Ok(new { Mensagens = informacoes.ToArray() });
            }

             return NotFound("Nenhum dado encontrado");
        }
    }
}

