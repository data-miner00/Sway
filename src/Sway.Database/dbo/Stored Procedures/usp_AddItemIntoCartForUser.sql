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

	MERGE INTO [dbo].[CartItems] T
	USING (
		SELECT
			@CartId ShoppingCartId,
			@ProductId ProductId,
			@Quantity Quantity
	) S
	ON T.ShoppingCartId = S.ShoppingCartId
	AND T.ProductId = S.ProductId
	WHEN MATCHED THEN
		UPDATE SET
			[Quantity] = T.Quantity + S.Quantity
	WHEN NOT MATCHED THEN
		INSERT
		(
			[ShoppingCartId],
			[ProductId],
			[Quantity]
		)
		VALUES
		(
			S.ShoppingCartId,
			S.ProductId,
			S.Quantity
		);

	COMMIT TRANSACTION

	RETURN @@ERROR;
END