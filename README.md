# Talent Pool

Exemplo de CRUD de um Banco de Talentos para Desenvolvedores

## Tecnologias Utilizadas

### Banco de Dados (Microsoft SQL Server 2008 R2 Express Edition)

* db/CREATE.sql - DDL das Tabelas e Relacionamentos da Database "TalentPoolDb"  
* db/ERD.png - Diagrama Entidade-Relacionamento

### Back-End (C# - .NET Core)

* src/Kernel - Biblioteca Genérica Utilitária  
* src/EntityFramework - Biblioteca Genérica para Acesso aos Dados (Microsoft.EntityFrameworkCore), utilizando os padrões "Repository", "Unit of Work" e "Dependency Injection"  
* src/TPDomain - Biblioteca do Domínio e Modelo do Negócio do Projeto  

### Front-End (C# - .NET Core; TypeScript - Angular)

* src/TPWeb - Aplicação Web (Microsoft.AspNetCore.SpaServices.Extensions), utilizando os padrões "MVVM" e "Dependency Injection"
