-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetRatingsForProduct]
	@ProductId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRAN

	SELECT * FROM [dbo].[ProductRatings]
	WHERE [ProductId] = @ProductId;

	COMMIT TRAN

	RETURN @@ERROR;
END