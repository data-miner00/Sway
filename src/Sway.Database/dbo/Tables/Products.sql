CREATE TABLE [dbo].[Products] (
    [Id]          NVARCHAR (50)  NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [Price]       MONEY          NOT NULL,
    [InStock]     INT            NOT NULL,
    [SKU]         NVARCHAR (255) NULL,
    [BrandId]     NVARCHAR (50)  NOT NULL,
    [CategoryId]  NVARCHAR (50)  NULL,
    [CreatedAt]   DATETIME2 (7)  NOT NULL,
    [ModifiedAt]  DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

