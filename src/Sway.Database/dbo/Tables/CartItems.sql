CREATE TABLE [dbo].[CartItems] (
    [Id]             UNIQUEIDENTIFIER CONSTRAINT [DF_CartItems_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [ShoppingCartId] UNIQUEIDENTIFIER NOT NULL,
    [ProductId]      UNIQUEIDENTIFIER NOT NULL,
    [Quantity]       INT           NOT NULL,
    [CreatedAt]      DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]     DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
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

        DECLARE @CartId UNIQUEIDENTIFIER;

		UPDATE [dbo].[CartItems]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[CartItems] T
		INNER JOIN inserted I ON T.ID = I.ID;

        SELECT @CartId = [ShoppingCartId] FROM inserted;

        UPDATE [dbo].[ShoppingCarts]
        SET [ModifiedAt] = GETDATE()
        WHERE [Id] = @CartId;
	END;


GO

CREATE TRIGGER [dbo].[Trigger_CartItems_OnInsert]
    ON [dbo].[CartItems]
    FOR INSERT
    AS
    BEGIN
        SET NOCOUNT ON;

        DECLARE @CartId UNIQUEIDENTIFIER;

        SELECT @CartId = [ShoppingCartId] FROM inserted;

        UPDATE [dbo].[ShoppingCarts]
        SET [ModifiedAt] = GETDATE()
        WHERE [Id] = @CartId;
    END
GO

CREATE TRIGGER [dbo].[Trigger_CartItems_OnDelete]
    ON [dbo].[CartItems]
    FOR DELETE
    AS
    BEGIN
        SET NOCOUNT ON;

        DECLARE @CartId UNIQUEIDENTIFIER;

        SELECT @CartId = [ShoppingCartId] FROM deleted;

        UPDATE [dbo].[ShoppingCarts]
        SET [ModifiedAt] = GETDATE()
        WHERE [Id] = @CartId;
    END