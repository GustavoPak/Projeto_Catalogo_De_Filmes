using CatalogoFilmes.Application.Interfaces;
using CatalogoFilmes.Application.Utilities;
using CatalogoFilmes.Domain.Entities;
using CatalogoFilmes.Domain.Exceptions;
using CatalogoFilmes.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Application.Validators
{
    public class FilmeValidator
    {
        private readonly INotificator _notificator;

        public FilmeValidator(INotificator notificator)
        {
            _notificator = notificator;
        }

        public bool Validate(Filme filme)
        {
            if (filme.Titulo.Length > 25 || filme.Titulo.Length <= 2)
            {
                _notificator.Add(EnumTipoNofication.ClientError, "O título deve ter entre 2 e 25 caracteres.");
            }

            if (filme.Descricao.Length > 150 || filme.Descricao.Length < 5 || filme.Descricao == null)
            {
                _notificator.Add(EnumTipoNofication.ClientError, "A descrição deve ter entre 5 e 150 caracteres.");
            }

            if (filme.Diretor == null || filme.Diretor.Length > 25 || filme.Diretor.Length < 3)
            {
                _notificator.Add(EnumTipoNofication.ClientError, "O nome do diretor deve ter entre 3 e 25 caracteres.");
            }

            if (filme.Lancamento > DateTime.Now.AddDays(1))
            {
                _notificator.Add(EnumTipoNofication.ClientError, "A data não pode ser maior que a data atual.");
            }

            return _notificator.ListNotificacoes.Count > 0;
        }
    }
}
    



