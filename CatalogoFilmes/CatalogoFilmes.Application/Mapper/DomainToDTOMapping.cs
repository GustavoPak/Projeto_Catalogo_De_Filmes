using AutoMapper;
using CatalogoFilmes.Application.DTO;
using CatalogoFilmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Application.Mapper
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Filme, FilmeDTO>().ReverseMap();
        }
    }
}
