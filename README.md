# Talent Pool

Exemplo de CRUD de um Banco de Talentos para Desenvolvedores  

![](/misc/ClassDiagram.png)

## Tecnologias Utilizadas

### Banco de Dados (Microsoft SQL Server 2008 R2 Express Edition)

### Back-End (C# - .NET Core)

* src/Kernel - Biblioteca Genérica Utilitária  
* src/EntityFramework - Biblioteca Genérica para Acesso aos Dados (Microsoft.EntityFrameworkCore), com validações de dados através de DataAnnotations, utilizando o padrão "Repository"  
* src/TPDomain - Biblioteca do Domínio e Modelo do Negócio do Projeto  
* src/TPDomainTests - Testes Unitários (MSTest) dos Serviços de Domínio e Modelo do Negócio do Projeto  
* src/TPData - Biblioteca de Configuração para Acesso aos Dados específicos do Projeto, com IEntityTypeConfiguration, Migrations e Seed, utilizando o padrão"Unit of Work" (DbContext)  

### Front-End (C# - .NET Core; TypeScript - Angular)

* src/TPWeb - Aplicação Web (Microsoft.AspNetCore.SpaServices.Extensions), utilizando os padrões "MVC", "MVVM" e "Dependency Injection" para Inversão de Controle
