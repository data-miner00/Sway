CREATE TYPE [dbo].[typ_OrderLines] AS TABLE
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[Quantity] INT NOT NULL,
	[UnitPrice] MONEY NOT NULL,
	[TotalPrice] MONEY NOT NULL
)
