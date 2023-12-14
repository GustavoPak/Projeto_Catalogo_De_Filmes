using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoFilmes.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }

        public static void When(bool erro,string message)
        {
            if (erro == true)
            {
                throw new DomainException("Erro no dominio! " + message);
            }
        }
    }
}
