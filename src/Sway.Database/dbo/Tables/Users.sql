CREATE TABLE [dbo].[Users] (
    [Id]           NVARCHAR (50) NOT NULL,
    [Username]     NVARCHAR (50) NOT NULL,
    [Status]       NVARCHAR (50) NOT NULL,
    [ProfileId]    NVARCHAR (50) NOT NULL,
    [CredentialId] NVARCHAR (50) NOT NULL,
    [CartId]       NVARCHAR (50) NULL,
    [Role]         NVARCHAR (50) NOT NULL,
    [DateOfBirth]  DATETIME2 (7) NOT NULL,
    [CreatedAt]    DATETIME2 (7) NOT NULL,
    [ModifiedAt]   DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

