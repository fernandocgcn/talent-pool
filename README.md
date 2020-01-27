# Talent Pool

Exemplo de CRUD de um Banco de Talentos

## Tecnologias Utilizadas

### Banco de Dados

Microsoft SQL Server 2008 R2 Express Edition (Database "TalentPoolDb")

### Back-End (C# - netcoreapp3.1)

src/Kernel - Biblioteca Genérica Utilitária  
src/EntityFramework - Biblioteca Genérica para Acesso aos Dados (Microsoft.EntityFrameworkCore), utilizando os padrões "Repository" e "Unit of Work"  
src/TPDomain - Biblioteca do Domínio e Modelo do Negócio do Projeto  

### Front-End (C# - netcoreapp3.1; Typescript - Angular)

src/TPWeb - Aplicação Web (Microsoft.AspNetCore.SpaServices.Extensions), utilizando os padrões "MVVM" e "Injeção de Dependência"
