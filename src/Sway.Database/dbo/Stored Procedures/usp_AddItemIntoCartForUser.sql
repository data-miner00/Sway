-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddItemIntoCartForUser]
	@UserId UNIQUEIDENTIFIER,
	@ProductId UNIQUEIDENTIFIER,
	@Quantity INT
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

	DECLARE @CartId UNIQUEIDENTIFIER;
	DECLARE @Outputs TABLE ([ShoppingCartIds] UNIQUEIDENTIFIER);

    BEGIN TRANSACTION

	SELECT @CartId = [CartId]
	FROM [dbo].[Users]
	WHERE [Id] = @UserId;

	IF @CartId IS NULL
	BEGIN

		EXEC [dbo].[usp_CreateShoppingCartForUser] @UserId;
		
	END

	INSERT INTO [dbo].[CartItems]
	(
		[ShoppingCartId],
		[ProductId],
		[Quantity]
	)
	VALUES
	(
		@CartId,
		@ProductId,
		@Quantity
	);

	COMMIT TRANSACTION

	RETURN @@ERROR;
END