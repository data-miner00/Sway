-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteProductRatingById]
	@Id INT
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRAN

	DELETE FROM [dbo].[ProductRatings]
	WHERE [Id] = @Id;

	COMMIT TRAN

	RETURN @@ERROR;
END