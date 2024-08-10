-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetTopExpensiveProducts] 
	@RowCount INT = 5
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP (@RowCount) WITH TIES
		[Id],
		[Name],
		[Description],
		[Price],
		[InStock],
		[SKU],
		[BrandId],
		[CategoryId],
		[CreatedAt],
		[ModifiedAt],
		[AverageRatings]
	FROM [dbo].[Products]
	ORDER BY [Price] DESC;
END