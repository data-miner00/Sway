CREATE TABLE [dbo].[Credentials] (
    [Id]                   UNIQUEIDENTIFIER CONSTRAINT [DF_Credentials_Id] DEFAULT NEWID() NOT NULL,
    [PasswordHash]         NVARCHAR (100) NOT NULL,
    [PasswordSalt]         NVARCHAR (50)  NOT NULL,
    [HashAlgorithm]        NVARCHAR (50)  NOT NULL,
    [PreviousPasswordHash] NVARCHAR (100) NULL,
    [CreatedAt]            DATETIME2 (7)  DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]           DATETIME2 (7)  DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Credentials] PRIMARY KEY CLUSTERED ([Id] ASC)
);

