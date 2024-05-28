CREATE TABLE [dbo].[PaymentMethods] (
    [Id]         NVARCHAR (50) NOT NULL,
    [UserId]     NVARCHAR (50) NOT NULL,
    [Type]       NVARCHAR (50) NOT NULL,
    [Provider]   NVARCHAR (50) NOT NULL,
    [AccountNo]  NVARCHAR (50) NOT NULL,
    [ExpiryDate] DATETIME2 (7) NOT NULL,
    [CreatedAt]  DATETIME2 (7) NOT NULL,
    [ModifiedAt] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED ([Id] ASC)
);

