-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAllProductsWithPagination]
	@OffsetCount INT = 0,
	@FetchCount INT = 10
AS
BEGIN
	SET NOCOUNT ON;

    SELECT
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
	FROM
		[dbo].[Products]
	ORDER BY
		[Price],
		[Name]
	OFFSET @OffsetCount ROWS 
	FETCH NEXT @FetchCount ROWS ONLY;
END