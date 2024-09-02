CREATE TABLE [dbo].[CartItems] (
    [Id]             UNIQUEIDENTIFIER CONSTRAINT [DF_CartItems_Id] DEFAULT (newsequentialid()) NOT NULL,
    [ShoppingCartId] UNIQUEIDENTIFIER NOT NULL,
    [ProductId]      UNIQUEIDENTIFIER NOT NULL,
    [Quantity]       INT              NOT NULL,
    [CreatedAt]      DATETIME2 (7)    DEFAULT (getdate()) NOT NULL,
    [ModifiedAt]     DATETIME2 (7)    DEFAULT (getdate()) NOT NULL,
    [IsDeleted]      BIT              DEFAULT ((0)) NOT NULL,
    [IsSelected]     BIT              CONSTRAINT [DF_CartItems_IsSelected] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CartItems_ShoppingCarts] FOREIGN KEY ([ShoppingCartId]) REFERENCES [dbo].[ShoppingCarts] ([Id])
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
        INNER JOIN inserted I ON T.Id = I.Id;

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
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Whether to include this item in the checkout page', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CartItems', @level2type = N'COLUMN', @level2name = N'IsSelected';

