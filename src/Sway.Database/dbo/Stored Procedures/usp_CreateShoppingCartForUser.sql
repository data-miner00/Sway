-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CreateShoppingCartForUser]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    DECLARE @IsAlreadyHasCart BIT;
	DECLARE @Outputs TABLE ([CartId] UNIQUEIDENTIFIER);
	DECLARE @CartId UNIQUEIDENTIFIER;

	BEGIN TRANSACTION

	SELECT @CartId = [CartId]
	FROM [dbo].[Users]
	WHERE [Id] = @UserId;

	IF @CartId IS NULL
	BEGIN
		
		INSERT INTO [dbo].[ShoppingCarts]
		OUTPUT inserted.Id INTO @Outputs
		DEFAULT VALUES;

		SELECT @CartId = [CartId]
		FROM @Outputs;

		UPDATE [dbo].[Users]
		SET [CartId] = @CartId
		WHERE [Id] = @UserId;
	END

	COMMIT TRANSACTION
END