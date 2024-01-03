using CatalogoFilmes.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Domain.Entities
{
 #nullable disable
    public sealed class Filme
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Diretor { get; private set; }
        public DateTime Lancamento { get; private set; }
    }
}
