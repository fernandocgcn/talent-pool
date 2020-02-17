# Talent Pool

Exemplo de CRUD de um Banco de Talentos para Desenvolvedores em um Projeto OO com uma Arquitetura Multicamadas  

![](/misc/ClassDiagram.png)

![](/misc/ComponentDiagram.png)

## Tecnologias Utilizadas

### Banco de Dados (Microsoft SQL Server 2008 R2 Express Edition)

### Back-End (C# - .NET Core)

* src/Common - Biblioteca Genérica Utilitária Comum aos Projetos  

* src/EntityFramework - Biblioteca Genérica para Acesso aos Dados (Microsoft.EntityFrameworkCore), com validações de dados através de DataAnnotations, utilizando os padrões "Repository" e "Unit of Work" (DbContext)  

* src/TPModel - Biblioteca do Modelo de Dados do Projeto  

* src/TPData - Biblioteca de Configuração para Acesso aos Dados Específicos do Projeto, utilizando Migrations com IEntityTypeConfiguration e Seed  

* src/TPDomain - Biblioteca do Domínio e Lógica do Negócio do Projeto  

* src/TPDomainTests - Testes Unitários (MSTest) dos Serviços do Domínio e Lógica do Negócio do Projeto  

### Front-End (C# - .NET Core; TypeScript/JavaScript/HTML/CSS - Angular com Bootstrap)

* src/TPWeb - Api Web MVC e Single Page Application (Microsoft.AspNetCore.SpaServices.Extensions), utilizando os padrões "MVC" e "Dependency Injection" para Inversão de Controle
