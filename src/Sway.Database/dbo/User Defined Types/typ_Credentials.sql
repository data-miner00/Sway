CREATE TYPE [dbo].[typ_Credentials] AS TABLE (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [PasswordHash]         NVARCHAR (100)   NOT NULL,
    [PasswordSalt]         NVARCHAR (50)    NOT NULL,
    [HashAlgorithm]        NVARCHAR (50)    NOT NULL,
    [PreviousPasswordHash] NVARCHAR (100)   NULL,
    [CreatedAt]            DATETIME2 (7)    NOT NULL,
    [ModifiedAt]           DATETIME2 (7)    NOT NULL);

