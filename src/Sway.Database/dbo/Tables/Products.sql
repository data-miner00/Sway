CREATE TABLE [dbo].[Products] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_Products_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [Price]       MONEY          NOT NULL,
    [InStock]     INT            NOT NULL,
    [SKU]         NVARCHAR (255) NULL,
    [BrandId]     UNIQUEIDENTIFIER NOT NULL,
    [CategoryId]  UNIQUEIDENTIFIER NULL,
    [CreatedAt]   DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]  DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Products_Price_Positive] CHECK ([Price] > 0),
    CONSTRAINT [CK_Products_InStock_Positive] CHECK ([InStock] > 0), 
    CONSTRAINT [FK_Products_Brands] FOREIGN KEY ([BrandId]) REFERENCES [Brands]([Id]), 
    CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]),
);

