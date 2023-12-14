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

        public Filme(int id, string titulo, string descricao, string diretor,DateTime lancamento)
        {
            ValidarDados(id, titulo, descricao, diretor, lancamento);
        }

        public void ValidarDados(int id,string titulo,string descricao,string diretor,DateTime lancamento)
        {
            DomainException.When(titulo == null, "O título é obrigatório!");
            DomainException.When(titulo.Length > 25, "Tamanho máximo do titulo atingido!");
            DomainException.When(titulo.Length <= 2, "Titulo muito curto!");
            
            DomainException.When(descricao.Length > 150, "Descrição deve ser menor!");
            DomainException.When(descricao.Length < 5, "Descrição muito curta");
            DomainException.When(descricao == null, "A descrição é obrigatória!");
            
            DomainException.When(diretor == null, "O Nome do diretor é obrigatório!");
            DomainException.When(diretor.Length > 25, "Tamanho máximo do nome foi atingido!");
            DomainException.When(diretor.Length < 3, "Nome precisa ter um tamanho minimo!");

            DomainException.When(lancamento > DateTime.Now.AddDays(1), "Data invalida! formato está no futuro");
            DomainException.When(lancamento.Year == 0 || lancamento.Month == 0 || lancamento.Year == 0000,"Insira uma data valida!");

            Titulo = titulo;
            Descricao = descricao;
            Diretor = diretor;
            Lancamento = lancamento;
            Id = id;
        }
    }
}
