-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_DeleteAddressById
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

	BEGIN TRANSACTION;

	DELETE FROM [dbo].[Addresses]
	WHERE [Id] = @Id;

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END