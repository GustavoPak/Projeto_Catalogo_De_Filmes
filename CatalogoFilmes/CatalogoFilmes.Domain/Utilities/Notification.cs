using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Domain.Utilities
{
    public class Notification
    {
        public EnumTipoNofication StatusCode { get; set; } = EnumTipoNofication.Informacao;
        public string Descricao { get; set; }
        public Notification(EnumTipoNofication tipo, string mensagem)
        {
            StatusCode = tipo;
            Descricao = mensagem;
        }
    }

    public enum EnumTipoNofication
    {
        Informacao = 200,
        ClientError = 400,
        ServerError = 500,
    }
}
