CREATE TABLE [dbo].[Coupons] (
    [Id]                 UNIQUEIDENTIFIER CONSTRAINT [DF_Coupons_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [OwnerId]            UNIQUEIDENTIFIER NOT NULL,
    [Code]               NVARCHAR (50) CONSTRAINT [UQ_Coupons_Code] UNIQUE NOT NULL,
    [Description]        NVARCHAR (255) NULL,
    [DiscountAmount]     NUMERIC (18)   NOT NULL,
    [DiscountUnit]       NVARCHAR (50)  NOT NULL,
    [ApplicableForBrand] UNIQUEIDENTIFIER  NULL,
    [AppliedToOrder]     UNIQUEIDENTIFIER NULL,
    [ExpireAt]           DATETIME2 (7)  NULL,
    [CreatedAt]          DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]         DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Coupons] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Coupons_Users] FOREIGN KEY ([OwnerId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Coupons_Brands] FOREIGN KEY ([ApplicableForBrand]) REFERENCES [Brands]([Id]),
    CONSTRAINT [FK_Coupons_Orders] FOREIGN KEY ([AppliedToOrder]) REFERENCES [Orders]([Id]), 
    CONSTRAINT [CK_Coupons_DiscountAmount_Positive] CHECK ([DiscountAmount] > 0)
);

