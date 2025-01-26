-- =============================================
-- Author:		Shaun Chong
-- Create date: 16 Jan 2025
-- Description:	Gets all user details for either valid or invalid email address.
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetUsersWithValidEmailAddress]
	@IsValid BIT = 1
AS
BEGIN
	SET NOCOUNT ON;

	IF @IsValid = 1
		SELECT [Id]
		  ,[Username]
		  ,[Status]
		  ,[DateOfBirth]
		  ,[Role]
		  ,[CreatedAt]
		  ,[ModifiedAt]
		  ,[Email]
		  ,[Phone]
		  ,[PhotoUrl]
		  ,[Description]
		  ,[HashAlgorithm]
		  ,[PasswordHash]
		  ,[PasswordSalt]
		  ,[PreviousPasswordHash]
		  ,[FirstName]
		  ,[LastName]
		FROM [dbo].[vw_UserDetails]
		WHERE [Email] LIKE '%_@__%.__%';
	ELSE
		SELECT [Id]
		  ,[Username]
		  ,[Status]
		  ,[DateOfBirth]
		  ,[Role]
		  ,[CreatedAt]
		  ,[ModifiedAt]
		  ,[Email]
		  ,[Phone]
		  ,[PhotoUrl]
		  ,[Description]
		  ,[HashAlgorithm]
		  ,[PasswordHash]
		  ,[PasswordSalt]
		  ,[PreviousPasswordHash]
		  ,[FirstName]
		  ,[LastName]
		FROM [dbo].[vw_UserDetails]
		WHERE [Email] NOT LIKE '%_@__%.__%';
END