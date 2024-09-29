-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateUserPasswordV2]
	@UserId UNIQUEIDENTIFIER,
	@PurportedOldPasswordHash NVARCHAR(100),
	@NewPasswordHash NVARCHAR(100),
	@ForceUpdate BIT = 0
AS
BEGIN
	DECLARE @CredentialId UNIQUEIDENTIFIER;
	DECLARE @CurrentPasswordHash NVARCHAR(100);

	SET NOCOUNT, XACT_ABORT ON;

	BEGIN TRANSACTION

	SELECT 
		@CurrentPasswordHash = [PasswordHash]
	FROM [dbo].[vw_UserCredentials]
	WHERE [UserId] = @UserId;

	SELECT
		@CredentialId = [CredentialId]
	FROM [dbo].[Users]
	WHERE [Id] = @UserId;

	IF (@ForceUpdate = 0 AND @CurrentPasswordHash <> @PurportedOldPasswordHash)
	BEGIN;
		THROW 51000, 'The current password does not match', 1;
	END

	UPDATE [dbo].[Credentials]
	SET
		[PasswordHash] = @NewPasswordHash,
		[PreviousPasswordHash] = @PurportedOldPasswordHash
	WHERE
		[Id] = @CredentialId;

	PRINT 'Done updating password';

	COMMIT TRANSACTION
END