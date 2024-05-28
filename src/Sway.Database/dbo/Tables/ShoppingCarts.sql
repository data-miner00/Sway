CREATE TABLE [dbo].[ShoppingCarts] (
    [Id]         NVARCHAR (50) NOT NULL,
    [CreatedAt]  DATETIME2 (7) NOT NULL,
    [ModifiedAt] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

