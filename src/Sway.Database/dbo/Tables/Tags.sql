﻿CREATE TABLE [dbo].[Tags] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_Tags_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [Name]       NVARCHAR (50) CONSTRAINT [UQ_Tags_Name] UNIQUE NOT NULL,
    [CreatedAt]  DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt] DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED ([Id] ASC)
);

