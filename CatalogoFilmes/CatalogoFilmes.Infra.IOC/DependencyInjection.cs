using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CatalogoFilmes.Application.Mapper;
using CatalogoFilmes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogoFilmes.Domain.Repositories;

using CatalogoFilmes.Infra.Data.Repositories;
using CatalogoFilmes.Application.Interfaces;
using CatalogoFilmes.Application.Services;
using CatalogoFilmes.Domain.Entities;

namespace CatalogoFilmes.Infra.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services,IConfiguration config)
        {
            services.AddAutoMapper(typeof(DomainToDTOMapping));

            services.AddDbContext<AppDbContext>(p => p.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
