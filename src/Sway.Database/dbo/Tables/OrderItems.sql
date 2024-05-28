CREATE TABLE [dbo].[OrderItems] (
    [Id]         NVARCHAR (50) NOT NULL,
    [OrderId]    NVARCHAR (50) NOT NULL,
    [ProductId]  NVARCHAR (50) NOT NULL,
    [Quantity]   INT           NOT NULL,
    [UnitPrice]  MONEY         NOT NULL,
    [TotalPrice] MONEY         NOT NULL,
    [CreatedAt]  DATETIME2 (7) NOT NULL,
    [ModifiedAt] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED ([Id] ASC)
);

