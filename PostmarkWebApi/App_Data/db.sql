USE [master]
GO

CREATE DATABASE [PostmarkMailbox]
GO

USE [PostmarkMailbox]
GO

 CREATE TABLE [OutboundMessageStatus] (
	[Id] TINYINT PRIMARY KEY IDENTITY (1, 1),
	[Name] VARCHAR(20) NOT NULL
 )
 GO

INSERT INTO [OutboundMessageStatus] VALUES ('Sent'), ('Delivered'), ('BouncedBack')
GO

CREATE TABLE [OutboundMessage] (
	[Id] BIGINT PRIMARY KEY IDENTITY (1, 1),
	[SendFrom] NVARCHAR(256) NOT NULL,
	[SendTo] NVARCHAR(256) NOT NULL,
	[Subject] NVARCHAR(128) NOT NULL, 
	[TextBody] NVARCHAR(MAX) NOT NULL, 
	[UserGuid] UNIQUEIDENTIFIER NOT NULL,
	[StatusId] TINYINT NOT NULL FOREIGN KEY REFERENCES [OutboundMessageStatus]([Id]),
	[PostmarkMessageId] UNIQUEIDENTIFIER NOT NULL,
	[PostmarkErrorCode] INT NULL,
	[PostmarkStatus] NVARCHAR(MAX) NULL,
	[PostmarkDescription] NVARCHAR(MAX) NULL,
	[SubmittedAt] DATETIME NULL,
	[DeliveredAt] DATETIME NULL,
	[BouncedAt] DATETIME NULL,
 )
 GO
