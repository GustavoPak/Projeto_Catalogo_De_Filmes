using CatalogoFilmes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoFilmes.Domain.Utilities;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using CatalogoFilmes.Domain.Repositories;


namespace CatalogoFilmes.Application.Services
{
    public abstract class ServiceBase
    {
        private readonly INotificator _notificator;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _uof;

        public ServiceBase(IServiceProvider service)
        {
            _notificator = service.GetRequiredService<INotificator> ();
            _mapper = service.GetRequiredService<IMapper>();
            _uof = service.GetRequiredService<IUnitOfWork>();
        }

        protected void Notify(EnumTipoNofication type, string message) 
            => _notificator.Add(type,message); 
    }
}
