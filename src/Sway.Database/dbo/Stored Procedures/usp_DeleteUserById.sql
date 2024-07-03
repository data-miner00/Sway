-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteUserById]
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @Outputs TABLE (
		[ProfileId] UNIQUEIDENTIFIER,
		[CredentialId] UNIQUEIDENTIFIER,
		[CartId] UNIQUEIDENTIFIER
	);

	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	DELETE FROM [dbo].[Users]
	OUTPUT DELETED.ProfileId, DELETED.CredentialId, DELETED.CartId
	INTO @Outputs
	WHERE [Id] = @Id;

	IF EXISTS (SELECT 1 FROM @Outputs)
	BEGIN

		DELETE FROM [dbo].[UserProfiles]
		WHERE [Id] IN (SELECT [ProfileId] FROM @Outputs);

		DELETE FROM [dbo].[Credentials]
		WHERE [Id] IN (SELECT [CredentialId] FROM @Outputs);

		DELETE FROM [dbo].[CartItems]
		WHERE [ShoppingCartId] IN (SELECT [CartId] FROM @Outputs);

		DELETE FROM [dbo].[ShoppingCarts]
		WHERE [Id] IN (SELECT [CartId] FROM @Outputs);

	END

	COMMIT TRANSACTION

	RETURN @@ERROR;
END