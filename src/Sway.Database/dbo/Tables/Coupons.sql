CREATE TABLE [dbo].[Coupons] (
    [Id]                 NVARCHAR (50)  NOT NULL,
    [OwnerId]            NVARCHAR (50)  NOT NULL,
    [Code]               NVARCHAR (50)  NOT NULL,
    [Description]        NVARCHAR (255) NULL,
    [DiscountAmount]     NUMERIC (18)   NOT NULL,
    [DiscountUnit]       NVARCHAR (50)  NOT NULL,
    [ApplicableForBrand] NVARCHAR (50)  NULL,
    [AppliedToOrder]     NVARCHAR (50)  NULL,
    [ExpireAt]           DATETIME2 (7)  NULL,
    [CreatedAt]          DATETIME2 (7)  NOT NULL,
    [ModifiedAt]         DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Coupons] PRIMARY KEY CLUSTERED ([Id] ASC)
);

