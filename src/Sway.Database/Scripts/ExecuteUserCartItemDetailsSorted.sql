USE [Sway]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[usp_GetUserCartItemDetailsSorted]
		@UserId = '2BA7AD7C-4731-43BF-AE9C-28B0BD2B0095',
		@SortColumn = N'p.Name',
		@SortOrder = N'DESC'

SELECT	'Return Value' = @return_value

GO
