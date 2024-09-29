-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_UpdateUserPassword
	@Username VARCHAR(50),
	@NewPasswordHash VARCHAR(100)
AS
BEGIN
	DECLARE @UserId UNIQUEIDENTIFIER;
	DECLARE @CredentialId UNIQUEIDENTIFIER;
	DECLARE @OldPasswordHash VARCHAR(100);

	SET NOCOUNT, XACT_ABORT ON;
	SET STATISTICS IO, TIME ON;

	BEGIN TRANSACTION;

	SELECT 
		@UserId = [UserId],
		@OldPasswordHash = [PasswordHash]
	FROM [dbo].[vw_UserCredentials]
	WHERE [Username] = @Username;

	SELECT
		@CredentialId = [CredentialId]
	FROM [dbo].[Users]
	WHERE [Username] = @Username;

	MERGE [dbo].[Credentials] T
	USING [dbo].[Users] S
	ON T.Id = S.CredentialId
	WHEN MATCHED AND [CredentialId] = @CredentialId THEN
		UPDATE
			SET
				[PasswordHash] = @NewPasswordHash,
				[PreviousPasswordHash] = @OldPasswordHash
	WHEN NOT MATCHED BY TARGET THEN
		INSERT ([PasswordHash], [PasswordSalt], [HashAlgorithm])
		VALUES (@NewPasswordHash, CONVERT(VARCHAR(100), NEWID()), 'SHA256')
 
	WHEN NOT MATCHED BY SOURCE THEN
		DELETE;

	COMMIT TRANSACTION;
END