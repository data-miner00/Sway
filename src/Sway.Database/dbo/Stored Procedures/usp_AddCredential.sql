-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_AddCredential
	@PasswordHash NVARCHAR(100),
	@PasswordSalt NVARCHAR(50),
	@HashAlgorithm NVARCHAR(50),
	@RowId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
	DECLARE @OutputTable TABLE (Id UNIQUEIDENTIFIER);
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;
		
		INSERT INTO [dbo].[Credentials]
		(
			[PasswordHash],
			[PasswordSalt],
			[HashAlgorithm]
		)
		OUTPUT inserted.Id INTO @OutputTable
		VALUES
		(
			@PasswordHash,
			@PasswordSalt,
			@HashAlgorithm
		);

	COMMIT TRANSACTION;

	SELECT @RowId = Id FROM @OutputTable;
END