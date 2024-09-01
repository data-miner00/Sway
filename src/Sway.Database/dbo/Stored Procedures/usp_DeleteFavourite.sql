-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteFavourite]
	@UserId UNIQUEIDENTIFIER,
	@ProductId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Favourites]
	WHERE
		[UserId] = @UserId
	AND [ProductId] = @ProductId;

END