-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateUser]
	@Id UNIQUEIDENTIFIER,
	@Username NVARCHAR(50),
	@Status NVARCHAR(50),
	@ProfileId UNIQUEIDENTIFIER,
	@CredentialId UNIQUEIDENTIFIER,
	@CartId UNIQUEIDENTIFIER,
	@Role NVARCHAR(50),
	@DateOfBirth DATETIME2(7)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	UPDATE [dbo].[Users]
	SET
		[Username] = @Username,
		[Status] = @Status,
		[ProfileId] = @ProfileId,
		[CredentialId] = @CredentialId,
		[CartId] = @CartId,
		[Role] = @Role,
		[DateOfBirth] = @DateOfBirth
	WHERE
		[Id] = @Id;

	COMMIT TRANSACTION

	RETURN @@ERROR;
END