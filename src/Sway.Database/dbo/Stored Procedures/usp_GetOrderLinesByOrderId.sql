-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetOrderLinesByOrderId]
	@OrderId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

    SELECT
		p.Name ProductName,
		ol.Quantity,
		ol.UnitPrice,
		ol.TotalPrice
	FROM
		[dbo].[OrderItems] ol
		JOIN
		[dbo].[Products] p
	ON ol.ProductId = p.Id
	WHERE ol.[OrderId] = @OrderId;
END