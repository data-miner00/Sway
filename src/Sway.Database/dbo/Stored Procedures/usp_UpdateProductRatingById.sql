-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateProductRatingById]
	@Id INT,
	@Rating INT,
	@Comment NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRAN

	UPDATE [dbo].[ProductRatings]
	SET
		[Rating] = @Rating,
		[Comment] = @Comment
	WHERE
		[Id] = @Id;

	COMMIT TRAN

	RETURN @@ERROR;
END