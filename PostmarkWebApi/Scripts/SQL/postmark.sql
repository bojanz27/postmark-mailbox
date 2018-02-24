USE [master]
GO

CREATE DATABASE [PostmarkMailbox]
GO

USE [PostmarkMailbox]
GO

CREATE TABLE [Message] (
	[Id] BIGINT PRIMARY KEY IDENTITY (1, 1),
	[SendFrom] NVARCHAR(254) NOT NULL,
	[SendTo] NVARCHAR(254) NOT NULL,
	[Subject] NVARCHAR(254) NOT NULL, -- check this 
	[TextBody] NVARCHAR(MAX) NOT NULL, -- chekc this
	[Status] NVARCHAR(MAX) NULL,
	[ErrorCode] INT NULL,
	[DateCreated] DATETIME NOT NULL,
	[DateUpdated] DATETIME NOT NULL,
	[UserGuid] UNIQUEIDENTIFIER NOT NULL,
 )
 GO

 --dont use this for now
 --CREATE TABLE [MessageStatusHistory] (
	--[Id] BIGINT PRIMARY KEY IDENTITY (1, 1),
	--[MessageId] BIGINT NOT NULL FOREIGN KEY REFERENCES [Message] ([Id]),
	--[Status] NVARCHAR(MAX) NULL,
	--[ValidFrom] DATETIME NOT NULL,
	--[ValidTo] DATETIME NOT NULL,
 --)
 --GO

