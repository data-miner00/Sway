CREATE TABLE [dbo].[Orders] (
    [Id]                NVARCHAR (50) NOT NULL,
    [UserId]            NVARCHAR (50) NOT NULL,
    [Status]            NVARCHAR (50) NOT NULL,
    [TotalAmount]       MONEY         NOT NULL,
    [Currency]          NVARCHAR (50) NOT NULL,
    [PaymentInfoId]     NVARCHAR (50) NOT NULL,
    [ShippingAddressId] NVARCHAR (50) NOT NULL,
    [BillingAddressId]  NVARCHAR (50) NULL,
    [CreatedAt]         DATETIME2 (7) NOT NULL,
    [ModifiedAt]        DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

