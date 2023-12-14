using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoFilmes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopularFilmes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Filmes(Titulo, Descricao, Diretor, Lancamento) Values('Terror em coma','Filme de terror','Mark demil','03/02/2001')");
            migrationBuilder.Sql("Insert into Filmes(Titulo, Descricao, Diretor, Lancamento) Values('Aventura em selva 2','Filme de aventura','Carl Mendes','05/06/1985')");
            migrationBuilder.Sql("Insert into Filmes(Titulo, Descricao, Diretor, Lancamento) Values('Corridas em marte','Filme de corrida','Oliva gray','08/02/2007')");
            migrationBuilder.Sql("Insert into Filmes(Titulo, Descricao, Diretor, Lancamento) Values('Voando alto','Filme de ação','remond travel','05/06/2001')");
            migrationBuilder.Sql("Insert into Filmes(Titulo, Descricao, Diretor, Lancamento) Values('Rio 2','Filme de ação e suspense','Reminem silver','06/07/2004')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Filmes");
        }
    }
}
