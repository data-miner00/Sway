-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddUser]
	@Username NVARCHAR(50),
	@Status NVARCHAR(50),
	@ProfileId UNIQUEIDENTIFIER,
	@CredentialId UNIQUEIDENTIFIER,
	@CartId UNIQUEIDENTIFIER,
	@Role NVARCHAR(50),
	@DateOfBirth DATETIME2(7)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	INSERT INTO [dbo].[Users]
	(
		[Username],
		[Status],
		[ProfileId],
		[CredentialId],
		[CartId],
		[Role],
		[DateOfBirth]
	)
	VALUES
	(
		@Username,
		@Status,
		@ProfileId,
		@CredentialId,
		@CartId,
		@Role,
		@DateOfBirth
	);

	COMMIT TRANSACTION

	RETURN @@ERROR;
END