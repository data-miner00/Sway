-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateUserProfile]
	@UserId UNIQUEIDENTIFIER,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Email NVARCHAR(50),
	@Phone NVARCHAR(50),
	@PhotoUrl NVARCHAR(255),
	@Description NVARCHAR(255)
AS
BEGIN
	DECLARE @ProfileId UNIQUEIDENTIFIER;

	SET NOCOUNT ON;

	SELECT @ProfileId = [ProfileId]
	FROM [dbo].[Users]
	WHERE [Id] = @UserId;

	IF @ProfileId IS NOT NULL
	BEGIN
		UPDATE [dbo].[UserProfiles]
		SET
			[FirstName] = @FirstName,
			[LastName] = @LastName,
			[Email] = @Email,
			[Phone] = @Phone,
			[PhotoUrl] = @PhotoUrl,
			[Description] = @Description
		WHERE
			[Id] = @ProfileId;
	END

END