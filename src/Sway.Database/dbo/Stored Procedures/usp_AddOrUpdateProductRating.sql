-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddOrUpdateProductRating]
	@ProductId UNIQUEIDENTIFIER,
	@AuthorId UNIQUEIDENTIFIER,
	@Rating INT,
	@Comment NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRAN

	MERGE INTO [dbo].[ProductRatings] T
	USING (
		SELECT
			@ProductId ProductId,
			@AuthorId AuthorId,
			@Rating Rating,
			@Comment Comment
	) S
	ON T.ProductId = S.ProductId
	AND T.AuthorId = S.AuthorId
	WHEN MATCHED THEN
		UPDATE SET
			[Rating] = S.Rating,
			[Comment] = S.Comment
	WHEN NOT MATCHED THEN
		INSERT ([Rating], [Comment])
		VALUES (S.Rating, S.Comment);

	COMMIT TRAN

	RETURN @@ERROR;
END