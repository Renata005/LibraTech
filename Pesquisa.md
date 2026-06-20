# Desafio Técnico de Pesquisa

## Introdução

Durante o desenvolvimento de aplicações utilizando ASP.NET Core MVC, Entity Framework Core e SQLite, é importante entender como essas tecnologias funcionam internamente. Além de criar telas e implementar funcionalidades, compreender a arquitetura da aplicação facilita a manutenção do sistema e torna o desenvolvimento mais eficiente.

---

# Injeção de Dependência no ASP.NET Core

## O que é Injeção de Dependência?

A Injeção de Dependência (Dependency Injection - DI) é um recurso do ASP.NET Core responsável por fornecer automaticamente objetos e serviços para as classes da aplicação.
Em vez de criar manualmente uma conexão com o banco de dados dentro de um Controller, por exemplo, o próprio framework é responsável por fornecer essa dependência.
Isso deixa o código mais organizado, reduz o acoplamento entre as classes e facilita futuras manutenções.

---

## Ciclos de vida dos serviços

### Transient

No ciclo de vida Transient, uma nova instância do serviço é criada toda vez que ele é solicitada.
Esse tipo é recomendado para serviços simples e que não precisam compartilhar informações.

### Scoped

No Scoped, uma única instância é criada durante toda a requisição do usuário.
Esse é o ciclo normalmente utilizado pelo Entity Framework Core, pois cada requisição trabalha com seu próprio contexto do banco de dados.

### Singleton

No Singleton, apenas uma instância é criada e compartilhada por toda a aplicação.
É indicado para serviços que armazenam configurações ou dados em cache.

### Por que o banco de dados não deve ser Singleton?

Como várias requisições poderiam utilizar o mesmo contexto simultaneamente, poderiam ocorrer problemas de concorrência, conflitos e inconsistências nos dados. Por esse motivo, o DbContext geralmente é registrado como Scoped.

---

# Entity Framework Core e ORM

## O que é uma ORM?

ORM (Object Relational Mapping) é uma tecnologia que faz a ligação entre os objetos criados em uma linguagem de programação e as tabelas do banco de dados.
No caso do Entity Framework Core, as classes desenvolvidas em C# podem ser transformadas automaticamente em tabelas, sem a necessidade de escrever manualmente comandos SQL para criação e manipulação dos dados.

### Vantagens

* Maior produtividade;
* Menor quantidade de código SQL manual;
* Facilidade de manutenção;
* Código mais organizado;
* Maior integração com o C#.

---

## O que significa trabalhar com Code-First?

Na abordagem Code-First, o banco de dados é criado a partir das classes desenvolvidas no projeto.
Primeiro são criadas as entidades em C#, e depois o Entity Framework Core é responsável por gerar as tabelas correspondentes no banco de dados.
Essa abordagem facilita alterações futuras e permite que a estrutura do banco acompanhe a evolução do sistema.

---

## Como funcionam as Migrations?

As Migrations são responsáveis por registrar as alterações realizadas nas entidades.
Quando executamos:

```bash
dotnet ef migrations add InitialCreate
```

o Entity Framework gera arquivos contendo as modificações necessárias.
Posteriormente, ao executar:

```bash
dotnet ef database update
```

o EF Core verifica uma tabela interna chamada `__EFMigrationsHistory`, que registra quais migrations já foram aplicadas anteriormente.
Assim, apenas as alterações que ainda não foram executadas são aplicadas ao banco de dados.

---

# SQLite

## Vantagens do SQLite

O SQLite é bastante utilizado em ambientes de desenvolvimento e testes devido às seguintes características:
* Instalação simples;
* Não necessita de servidor;
* Armazena os dados em um único arquivo;
* Baixo consumo de recursos;
* Fácil configuração;
* Ideal para projetos pequenos e protótipos.

Essas características tornam o SQLite uma boa escolha para ambientes acadêmicos e para as fases iniciais de um projeto.

---

## Qual é a principal limitação do SQLite?

O principal ponto fraco do SQLite está relacionado à concorrência.
Como o banco é armazenado em um único arquivo, muitas operações de escrita simultâneas podem causar bloqueios e perda de desempenho.
Em sistemas com muitos usuários realizando gravações ao mesmo tempo, podem ocorrer filas de escrita e redução da performance da aplicação.

---

## Quando migrar para PostgreSQL ou SQL Server?

Quando a aplicação cresce e passa a ter muitos usuários, torna-se necessário utilizar bancos de dados mais robustos.
Soluções como PostgreSQL e SQL Server oferecem:
* Melhor desempenho;
* Maior capacidade de processamento;
* Melhor gerenciamento de concorrência;
* Maior escalabilidade;
* Recursos avançados de segurança e disponibilidade.

Por esse motivo, são mais adequados para aplicações em produção e sistemas que precisam atender muitos usuários simultaneamente.

---

# Conclusão

ASP.NET Core, Entity Framework Core e SQLite formam uma combinação bastante eficiente para o desenvolvimento de aplicações. Recursos como Injeção de Dependência, ORM e Migrations tornam o código mais organizado e aceleram o desenvolvimento.
Embora o SQLite seja uma excelente opção para desenvolvimento e testes, aplicações maiores e com muitos acessos simultâneos podem exigir a utilização de bancos de dados mais robustos, como PostgreSQL ou SQL Server.

---

## Autor

Renata Santana Lopes/Sistemas de Informação
