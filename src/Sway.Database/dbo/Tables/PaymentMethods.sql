CREATE TABLE [dbo].[PaymentMethods] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_PaymentMethods_Id] DEFAULT NEWID() NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
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
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_PaymentMethods_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
);


GO

CREATE TRIGGER [dbo].[Trigger_PaymentMethods_OnUpdate]
    ON [dbo].[PaymentMethods]
    AFTER UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;

        UPDATE [dbo].[PaymentMethods]
        SET [ModifiedAt] = GETDATE()
        FROM [dbo].[PaymentMethods] T
        INNER JOIN inserted I ON T.Id = I.Id;
    END;


