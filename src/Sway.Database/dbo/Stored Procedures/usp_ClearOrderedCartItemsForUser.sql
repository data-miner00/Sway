-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ClearOrderedCartItemsForUser]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @CartId AS UNIQUEIDENTIFIER;
	
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRAN

	SELECT @CartId = [CartId] FROM [dbo].[Users]
	WHERE [Id] = @UserId

	DELETE FROM [dbo].[CartItems]
	WHERE [ShoppingCartId] = @CartId
	AND [IsSelected] = 1;

	COMMIT TRAN
END