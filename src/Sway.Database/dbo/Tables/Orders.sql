CREATE TABLE [dbo].[Orders] (
    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_Orders_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [UserId]            UNIQUEIDENTIFIER NOT NULL,
    [Status]            NVARCHAR (50) NOT NULL,
    [TotalAmount]       MONEY         NOT NULL,
    [Currency]          NVARCHAR (50) NOT NULL,
    [PaymentInfoId]     UNIQUEIDENTIFIER NOT NULL,
    [ShippingAddressId] UNIQUEIDENTIFIER NOT NULL,
    [BillingAddressId]  UNIQUEIDENTIFIER NULL,
    [CreatedAt]         DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]        DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [CK_Orders_TotalAmount_Positive] CHECK ([TotalAmount] > 0), 
    CONSTRAINT [FK_Orders_OrderShippingAddress] FOREIGN KEY ([ShippingAddressId]) REFERENCES [OrderAddresses]([Id]),
    CONSTRAINT [FK_Orders_OrderBillingAddress] FOREIGN KEY ([BillingAddressId]) REFERENCES [OrderAddresses]([Id]),
    CONSTRAINT [FK_Orders_OrderPaymentMethods] FOREIGN KEY ([PaymentInfoId]) REFERENCES [OrderPaymentMethods]([Id])
);

GO

CREATE TRIGGER [dbo].[Trigger_Orders_OnUpdate]
	ON [dbo].[Orders]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[Orders]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[Orders] T
        INNER JOIN inserted I ON T.Id = I.Id;
	END;

