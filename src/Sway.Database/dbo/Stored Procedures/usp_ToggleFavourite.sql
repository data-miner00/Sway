-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ToggleFavourite]
	@UserId UNIQUEIDENTIFIER,
	@ProductId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	MERGE INTO [dbo].[Favourites] T
	USING (
		SELECT
			@UserId UserId,
			@ProductId ProductId
	) S
	ON (T.UserId = S.UserId AND T.ProductId = S.ProductId)
	WHEN MATCHED THEN
		DELETE
	WHEN NOT MATCHED THEN
		INSERT ([UserId], [ProductId])
		VALUES (S.UserId, S.ProductId);

END