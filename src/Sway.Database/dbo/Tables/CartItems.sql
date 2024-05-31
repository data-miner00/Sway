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


GO

CREATE TRIGGER [dbo].[Trigger_CartItems_OnUpdate]
	ON [dbo].[CartItems]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[CartItems]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[CartItems] T
		INNER JOIN inserted I ON T.ID = I.ID;    
	END;

