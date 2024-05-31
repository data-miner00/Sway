CREATE TABLE [dbo].[ShoppingCarts] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_ShoppingCarts_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [CreatedAt]  DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt] DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TRIGGER [dbo].[Trigger_ShoppingCarts_OnUpdate]
	ON [dbo].[ShoppingCarts]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[ShoppingCarts]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[ShoppingCarts] T
		INNER JOIN inserted I ON T.ID = I.ID;    
	END;

