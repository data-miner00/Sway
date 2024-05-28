CREATE TABLE [dbo].[CartItems] (
    [Id]             NVARCHAR (50) NOT NULL,
    [ShoppingCartId] NVARCHAR (50) NOT NULL,
    [ProductId]      NVARCHAR (50) NOT NULL,
    [Quantity]       INT           NOT NULL,
    [CreatedAt]      DATETIME2 (7) NOT NULL,
    [ModifiedAt]     DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED ([Id] ASC)
);

