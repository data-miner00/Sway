-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddFavourite]
	@UserId UNIQUEIDENTIFIER,
	@ProductId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Favourites]
	(
		[UserId],
		[ProductId]
	)
	VALUES
	(
		@UserId,
		@ProductId
	);
END