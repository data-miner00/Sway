CREATE TABLE [dbo].[OrderItems] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_OrderItems_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [OrderId]    UNIQUEIDENTIFIER NOT NULL,
    [ProductId]  UNIQUEIDENTIFIER NOT NULL,
    [Quantity]   INT           NOT NULL,
    [UnitPrice]  MONEY         NOT NULL,
    [TotalPrice] MONEY         NOT NULL,
    [CreatedAt]  DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt] DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]),
    CONSTRAINT [FK_OrderItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]), 
    CONSTRAINT [CK_OrderItems_Quantity_Positive] CHECK ([Quantity] > 0),
    CONSTRAINT [CK_OrderItems_UnitPrice_Positive] CHECK ([UnitPrice] > 0),
    CONSTRAINT [CK_OrderItems_TotalPrice_Positive] CHECK ([TotalPrice] > 0),
);


GO

CREATE TRIGGER [dbo].[Trigger_OrderItems_OnUpdate]
	ON [dbo].[OrderItems]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[OrderItems]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[OrderItems] T
		INNER JOIN inserted I ON T.ID = I.ID;    
	END;
