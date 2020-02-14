# Talent Pool

Exemplo de CRUD de um Banco de Talentos para Desenvolvedores em um Projeto OO com uma Arquitetura Multicamadas  

![](/misc/ClassDiagram.png)

## Tecnologias Utilizadas

### Banco de Dados (Microsoft SQL Server 2008 R2 Express Edition)

### Back-End (C# - .NET Core)

* src/Kernel - Biblioteca Genérica Utilitária  
* src/EntityFramework - Biblioteca Genérica para Acesso aos Dados (Microsoft.EntityFrameworkCore), com validações de dados através de DataAnnotations, utilizando o padrão "Repository"  
  
* src/TPModel - Biblioteca do Modelo de Dados do Projeto  
* src/TPData - Biblioteca de Configuração para Acesso aos Dados específicos do Projeto, com IEntityTypeConfiguration, Migrations e Seed, utilizando o padrão"Unit of Work" (DbContext)  
* src/TPDomain - Biblioteca do Domínio e Lógica de Negócio do Projeto  
  
* src/TPDomainTests - Testes Unitários (MSTest) dos Serviços de Domínio e Modelo do Negócio do Projeto  

### Front-End (C# - .NET Core; TypeScript - Angular)

* src/TPWeb - Web MVC Single Page Application (Microsoft.AspNetCore.SpaServices.Extensions), utilizando os padrões "MVC" e "Dependency Injection" para Inversão de Controle
