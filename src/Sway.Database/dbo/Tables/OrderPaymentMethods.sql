CREATE TABLE [dbo].[OrderPaymentMethods] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_OrderPaymentMethods_Id] DEFAULT NEWID() NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [Type]       NVARCHAR (50) NOT NULL,
    [Provider]   NVARCHAR (50) NOT NULL,
    [AccountNo]  NVARCHAR (50) NOT NULL,
    [ExpiryDate] DATETIME2 (7) NOT NULL,
    [CreatedAt]  DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt] DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_OrderPaymentMethods] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_OrderPaymentMethods_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
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
		INNER JOIN inserted I ON T.ID = I.ID;    
	END;


