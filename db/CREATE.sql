-- Banco de Talentos
USE [TalentPoolDb]
GO

-- Desenvolvedores Candidatos
CREATE TABLE [dbo].[tb_developer](
	[dev_id] [int] IDENTITY(1,1) NOT NULL,
	[dev_email] [varchar](255) NOT NULL,
	[dev_name] [varchar](255) NOT NULL,
	[dev_city] [varchar](255) NOT NULL,
	[dev_state] [varchar](255) NOT NULL,
	[dev_skype] [varchar](255) NOT NULL,
	[dev_whatsapp] [varchar](15) NOT NULL,
	[dev_salary] [money] NOT NULL,
	[dev_linkedin] [varchar](255) NULL,
	[dev_portfolio] [text] NULL,
	[dev_extra_knowledge] [text] NULL,
	[dev_crud_link] [varchar](255) NULL,
 CONSTRAINT [PK_tb_developer] PRIMARY KEY ([dev_id]),
 CONSTRAINT [UK_tb_developer] UNIQUE ([dev_email])
)
GO

-- Quantidades de Horas de Trabalho por Dia
CREATE TABLE [dbo].[tb_availability](
	[ava_id] [int] NOT NULL,
	[ava_description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tb_availability] PRIMARY KEY ([ava_id]))
GO

-- Horários de Trabalho
CREATE TABLE [dbo].[tb_working_time](
	[wot_id] [int] NOT NULL,
	[wot_description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tb_working_time] PRIMARY KEY ([wot_id])
)
GO

-- Conhecimentos Técnicos
CREATE TABLE [dbo].[tb_knowledge](
	[kno_id] [int] NOT NULL,
	[kno_name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tb_knowledge] PRIMARY KEY ([kno_id]))
GO

-- Disponibilidades de Horas por Dia do Desenvolvedor 
CREATE TABLE [dbo].[tb_developer_availability](
	[dev_id] [int] NOT NULL,
	[ava_id] [int] NOT NULL,
 CONSTRAINT [PK_tb_developer_availability] PRIMARY KEY ([dev_id], [ava_id]))
GO

-- Horários de Trabalho do Desenvolvedor
CREATE TABLE [dbo].[tb_developer_working_time](
	[dev_id] [int] NOT NULL,
	[wot_id] [int] NOT NULL,
 CONSTRAINT [PK_tb_developer_working_time] PRIMARY KEY CLUSTERED ([dev_id], [wot_id])
)
GO

-- Conhecimentos Técnicos do Desenvolvedor
CREATE TABLE [dbo].[tb_developer_knowledge](
	[dek_id] [int] NOT NULL,
	[dek_rate] [tinyint] NOT NULL,
	[dev_id] [int] NOT NULL,
	[kno_id] [int] NOT NULL,
 CONSTRAINT [PK_tb_developer_knowledge] PRIMARY KEY ([dek_id]))
GO

ALTER TABLE [dbo].[tb_developer_availability] 
ADD  CONSTRAINT [FK_tb_developer_availability_tb_developer] FOREIGN KEY([dev_id])
REFERENCES [dbo].[tb_developer] ([dev_id])
GO

ALTER TABLE [dbo].[tb_developer_availability] 
ADD  CONSTRAINT [FK_tb_developer_availability_tb_availability] FOREIGN KEY([ava_id])
REFERENCES [dbo].[tb_availability] ([ava_id])
GO

ALTER TABLE [dbo].[tb_developer_working_time] 
ADD  CONSTRAINT [FK_tb_developer_working_time_tb_developer] FOREIGN KEY([dev_id])
REFERENCES [dbo].[tb_developer] ([dev_id])
GO

ALTER TABLE [dbo].[tb_developer_working_time] 
ADD  CONSTRAINT [FK_tb_developer_working_time_tb_working_time] FOREIGN KEY([wot_id])
REFERENCES [dbo].[tb_working_time] ([wot_id])
GO

ALTER TABLE [dbo].[tb_developer_knowledge] 
ADD  CONSTRAINT [FK_tb_developer_knowledge_tb_developer] FOREIGN KEY([dev_id])
REFERENCES [dbo].[tb_developer] ([dev_id])
GO

ALTER TABLE [dbo].[tb_developer_knowledge] 
ADD  CONSTRAINT [FK_tb_developer_knowledge_tb_knowledge] FOREIGN KEY([kno_id])
REFERENCES [dbo].[tb_knowledge] ([kno_id])
GO
