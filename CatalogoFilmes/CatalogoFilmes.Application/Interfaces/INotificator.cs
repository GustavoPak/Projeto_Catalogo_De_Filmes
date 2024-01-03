using CatalogoFilmes.Domain.Utilities;

namespace CatalogoFilmes.Application.Interfaces
{
    public interface INotificator
    {
        List<Notification> ListNotificacoes { get; }

        void Add(EnumTipoNofication type, string message);
        void Clear();
    }
}