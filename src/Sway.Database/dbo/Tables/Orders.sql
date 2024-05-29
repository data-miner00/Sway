﻿CREATE TABLE [dbo].[Orders] (
    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_Orders_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [UserId]            UNIQUEIDENTIFIER NOT NULL,
    [Status]            NVARCHAR (50) NOT NULL,
    [TotalAmount]       MONEY         NOT NULL,
    [Currency]          NVARCHAR (50) NOT NULL,
    [PaymentInfoId]     NVARCHAR (50) NOT NULL,
    [ShippingAddressId] NVARCHAR (50) NOT NULL,
    [BillingAddressId]  NVARCHAR (50) NULL,
    [CreatedAt]         DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]        DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [CK_Orders_TotalAmount_Positive] CHECK ([TotalAmount] = 1)
);

