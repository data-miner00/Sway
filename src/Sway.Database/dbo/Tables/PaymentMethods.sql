CREATE TABLE [dbo].[PaymentMethods] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_PaymentMethods_Id] DEFAULT NEWID() NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [Type]       NVARCHAR (50) NOT NULL,
    [Provider]   NVARCHAR (50) NOT NULL,
    [AccountNo]  NVARCHAR (50) NOT NULL,
    [ExpiryDate] DATETIME2 (7) NOT NULL,
    [CreatedAt]  DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt] DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_PaymentMethods_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
);

