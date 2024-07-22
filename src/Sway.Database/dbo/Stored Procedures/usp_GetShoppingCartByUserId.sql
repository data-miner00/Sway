-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetShoppingCartByUserId]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @CartId UNIQUEIDENTIFIER;

	SET NOCOUNT, XACT_ABORT ON;
	
	SELECT @CartId = [CartId] FROM [dbo].[Users]
	WHERE [Id] = @UserId;

	IF @CartId IS NOT NULL
	BEGIN
		SELECT * FROM [dbo].[ShoppingCarts]
		WHERE [Id] = @CartId;
	END
END