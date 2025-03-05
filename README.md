<h1>API Catalogo de filmes</h1>

<p>Essa é uma API criada para relembrar todas as ferramentas e processos possieis que se pode adicionar na sua estrutura para ser otimizada,bem documentada e seguindo todas as
diretrizes de escabilidade,responsabilidade e princpios necessários</p>

<h2>Objetivo:</h2>
<p>Construir uma API que permita aos usuários listar filmes, adicionar um novo filme, atualizar dados de um filme existente e deletar um filme do catálogo.</p>

## Principais pontos

<ul>
  <li>Fiz a separação em camadas.</li>
  <li>Modelo se auto-valida.</li>
  <li>Utilizei o AutoMapper.</li>
  <li>Usei DTOs.</li>
  <li>Configurei as regras para o banco de dados no <code>OnModelCreating</code>.</li>
  <li>Implementei os testes unitários.</li>
  <li><strong>Dúvida na <code>CreatedAtRouteResult</code>?</strong> → Desnecessário.</li>
  <li><strong>Dúvida sobre o tipo <code>DateTime</code>?</strong> → O tipo dele não se formata de um jeito específico, terá que formatar em outro lugar, como na configuração de serialização do JSON.</li>
  <li>Implementei a paginação de dados.</li>
  <li>Formatei as datas configurando o <code>JsonConverter</code>.</li>
  <li>Implementei o <code>IRepository</code> genérico.</li>
  <li>Implementei os comentários XML para documentar a API.</li>
  <li>Configurei o tipo de retorno das <code>actions</code> para JSON.</li>
  <li>Implantei o <code>UnitOfWork</code>.</li>
  <li>Habilitei o CORS.</li>
  <li>Implementei o sistema <code>Notifier</code>, que trata os erros do modelo relatando ao cliente.</li>
  <li>Implementei o sistema de exceção, onde me é devolvido o erro específico com uma formatação bem melhor.</li>
</ul>
