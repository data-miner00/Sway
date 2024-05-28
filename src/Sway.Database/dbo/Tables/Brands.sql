CREATE TABLE [dbo].[Brands] (
    [Id]          NVARCHAR (50)  NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [LogoUrl]     NVARCHAR (255) NULL,
    [CreatedAt]   DATETIME2 (7)  NOT NULL,
    [ModifiedAt]  DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([Id] ASC)
);

