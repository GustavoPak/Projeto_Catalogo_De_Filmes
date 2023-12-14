using CatalogoFilmes.Domain.Entities;
using CatalogoFilmes.Domain.Exceptions;
using FluentAssertions;
using System;

namespace CatalogoFilmes.Domain.Tests
{
    public class FilmeUnitTest
    {
        [Fact]
        public void CreateFilme_WithValidParameters_NotTrhowException()
        {
            Action action = () => new Filme(5, "Teste unitario", "Conjunto de testes unitarios para teste", "Maccorati", new DateTime(2004, 12, 13));

            action.Should().NotThrow<DomainException>();
        }

        [Fact]
        public void CreateFilme_WithInvalidParameters_TrhowException()
        {
            Action action = () => new Filme(5, null, null, null, new DateTime(2025, 03, 02));

            action.Should().Throw<DomainException>();
        }

        [Fact]
        public void CreateFilme_WithFutureDate_TrhowException()
        {
            Action action = () => new Filme(5, "Mauricio", "Notas de coletania dinamica","Marilio", new DateTime(2025, 03, 02));

            action.Should().Throw<DomainException>();
        }

        [Fact]
        public void CreateFilme_WithInvalidDate_TrhowException()
        {
            Action action = () => new Filme(5, "Mauricio", "Notas de coletania dinamica", "Marilio", new DateTime(0000, 00, 00));

            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
