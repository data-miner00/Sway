CREATE TABLE [dbo].[OrderPaymentMethods] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_OrderPaymentMethods_Id] DEFAULT NEWID() NOT NULL,
    [OrderId]     UNIQUEIDENTIFIER NOT NULL,
    [Type]       NVARCHAR (50) NOT NULL,
    [Provider]   NVARCHAR (50) NOT NULL,
    [CVV]  INT NULL,
    [ExpiryDate] DATETIME2 (7) NULL,
    [CreatedAt]  DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt] DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [CardholderName] NVARCHAR(50) NULL, 
    [CardNumber] NVARCHAR(50) NULL, 
    [WalletAddress] NVARCHAR(255) NULL, 
    [CardIssuingCountry] NVARCHAR(50) NULL, 
    [CardIssuingBank] NVARCHAR(50) NULL, 
    [Currency] NVARCHAR(50) NOT NULL, 
    [Balance] MONEY NULL, 
    CONSTRAINT [PK_OrderPaymentMethods] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_OrderPaymentMethods_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id])
);


GO

CREATE TRIGGER [dbo].[Trigger_OrderPaymentMethods_OnUpdate]
	ON [dbo].[OrderPaymentMethods]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[OrderPaymentMethods]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[OrderPaymentMethods] T
		INNER JOIN inserted I ON T.Id = I.Id;
	END;


