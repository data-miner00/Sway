-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CreateNewUser]
	@Username NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DateOfBirth DATETIME2(7),
	@Email NVARCHAR(50),
	@Phone NVARCHAR(50),
	@PhotoUrl NVARCHAR(255),
	@Description NVARCHAR(255),
	@PasswordHash NVARCHAR(100),
	@PasswordSalt NVARCHAR(50),
	@HashAlgorithm NVARCHAR(50)
AS
BEGIN
	DECLARE @CredentialId UNIQUEIDENTIFIER;
	DECLARE @ProfileId UNIQUEIDENTIFIER;

	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;
		
		EXEC [dbo].[usp_AddCredential] @PasswordHash, @PasswordSalt, @HashAlgorithm, @CredentialId OUTPUT;

		EXEC [dbo].[usp_AddProfile] @Email, @Phone, @PhotoUrl, @Description, @FirstName, @LastName, @ProfileId OUTPUT;

		INSERT INTO [dbo].[Users]
		(
			[Username],
			[Status],
			[ProfileId],
			[CredentialId],
			[Role],
			[DateOfBirth]
		)
		VALUES
		(
			@Username,
			'Active',
			@ProfileId,
			@CredentialId,
			'Customer',
			@DateOfBirth
		);

	COMMIT TRANSACTION;
END