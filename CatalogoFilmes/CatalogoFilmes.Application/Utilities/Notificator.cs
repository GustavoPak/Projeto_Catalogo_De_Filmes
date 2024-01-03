using CatalogoFilmes.Application.Interfaces;
using CatalogoFilmes.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Application.Utilities
{
    public class Notificator : INotificator
    {
        public List<Notification> ListNotificacoes { get; } = new List<Notification>();

        public void Add(EnumTipoNofication type,string message)
        {
            ListNotificacoes.Add(new Notification(type,message));
        }

        public void Clear()
        {
            ListNotificacoes.Clear();
        }
    }
}
