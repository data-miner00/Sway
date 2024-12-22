-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Sync the units sold property of the Product table from the Order Line table.
-- =============================================
CREATE PROCEDURE [dbo].[usp_SyncProductUnitSold] 
AS
BEGIN
	SET NOCOUNT ON;

	WITH cte AS (
		SELECT
			p.Id Id,
			SUM(ol.Quantity) QuantitySold
		FROM
			[Products] p
			LEFT JOIN [OrderItems] ol
			ON p.Id = ol.ProductId
		GROUP BY
			p.[Id],
			p.[Name],
			p.[Description],
			p.[Price],
			p.[InStock],
			p.[SKU],
			p.[BrandId],
			p.[CategoryId],
			p.[CreatedAt],
			p.[ModifiedAt],
			p.[AverageRatings],
			p.[UnitsSold],
			p.[DeliveryTime],
			p.[Favourite],
			p.[IsDeleted]
	)
	UPDATE [dbo].[Products]
	SET
		[UnitsSold] = cte.QuantitySold
	FROM 
		[dbo].[Products]
		INNER JOIN cte
		ON Products.Id = cte.Id
	WHERE cte.QuantitySold IS NOT NULL;
END;
