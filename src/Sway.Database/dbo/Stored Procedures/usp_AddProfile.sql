-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_AddProfile
	@Email NVARCHAR(50),
	@Phone NVARCHAR(50),
	@PhotoUrl NVARCHAR(255),
	@Description NVARCHAR(255),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@RowId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
	DECLARE @OutputTable TABLE (Id UNIQUEIDENTIFIER);
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;
		
		INSERT INTO [dbo].[UserProfiles]
		(
			[Email],
			[Phone],
			[PhotoUrl],
			[Description],
			[FirstName],
			[LastName]
		)
		OUTPUT inserted.Id INTO @OutputTable
		VALUES
		(
			@Email,
			@Phone,
			@PhotoUrl,
			@Description,
			@FirstName,
			@LastName
		);

	COMMIT TRANSACTION;
	SELECT @RowId = Id FROM @OutputTable;
END