CREATE VIEW [dbo].[vw_OrderItemsWithWeightage]
AS
SELECT [Id]
      ,[OrderId]
      ,[ProductId]
      ,[Quantity]
      ,[UnitPrice]
      ,[TotalPrice]
      ,[CreatedAt]
      ,[ModifiedAt]
	  ,(TotalPrice / SUM(TotalPrice) OVER(PARTITION BY [OrderId])) * 100 AS WeightageOfOrder
  FROM [dbo].[OrderItems]
