-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ConsolidateCartItem]
AS
BEGIN
	DECLARE @Temp TABLE (
		[ShoppingCartId] UNIQUEIDENTIFIER,
		[ProductId] UNIQUEIDENTIFIER,
		[Quantity] INT
	);

	SET NOCOUNT, XACT_ABORT ON;

	BEGIN TRANSACTION

	INSERT INTO @Temp
    SELECT
		[ShoppingCartId],
		[ProductId],
		SUM([Quantity]) AS Quantity
	FROM [dbo].[CartItems]
	GROUP BY [ShoppingCartId], [ProductId];

	MERGE [dbo].[CartItems] T
	USING @Temp S
	ON (T.ShoppingCartId = S.ShoppingCartId AND T.ProductId = S.ProductId)
	WHEN MATCHED THEN DELETE;

	INSERT INTO [dbo].[CartItems]
	(
		[ShoppingCartId],
		[ProductId],
		[Quantity]
	)
	SELECT * FROM @Temp;

	COMMIT TRANSACTION

	RETURN @@ERROR;
END