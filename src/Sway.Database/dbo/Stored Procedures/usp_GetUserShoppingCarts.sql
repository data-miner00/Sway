-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetUserShoppingCarts]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @TempUserCart TABLE
	(
		[UserId] UNIQUEIDENTIFIER NOT NULL,
		[CartId] UNIQUEIDENTIFIER NULL,
		INDEX IX_C CLUSTERED([UserId], [CartId] DESC)
	);

	SET NOCOUNT ON;

    INSERT INTO @TempUserCart
	SELECT
		usr.Id,
		crt.Id
	FROM [dbo].[Users] usr
	LEFT JOIN [dbo].[ShoppingCarts] crt
	ON usr.CartId = crt.Id
	WHERE (@UserId IS NULL) OR (usr.Id = @UserId);

	SELECT * FROM @TempUserCart;
END