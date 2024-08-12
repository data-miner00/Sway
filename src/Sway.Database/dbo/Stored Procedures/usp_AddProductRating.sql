-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddProductRating]
	@ProductId UNIQUEIDENTIFIER,
	@AuthorId UNIQUEIDENTIFIER,
	@Rating INT,
	@Comment NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRAN

	INSERT INTO [dbo].[ProductRatings]
	(
		[ProductId],
		[AuthorId],
		[Rating],
		[Comment]
	)
	VALUES
	(
		@ProductId,
		@AuthorId,
		@Rating,
		@Comment
	);

	COMMIT TRAN

	RETURN @@ERROR;
END