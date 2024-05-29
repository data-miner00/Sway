CREATE TABLE [dbo].[CartItems] (
    [Id]             UNIQUEIDENTIFIER CONSTRAINT [DF_CartItems_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [ShoppingCartId] UNIQUEIDENTIFIER NOT NULL,
    [ProductId]      UNIQUEIDENTIFIER NOT NULL,
    [Quantity]       INT           NOT NULL,
    [CreatedAt]      DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]     DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_CartItems_ShoppingCarts] FOREIGN KEY ([ShoppingCartId]) REFERENCES [ShoppingCarts]([Id])
);

