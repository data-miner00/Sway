-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteOrderById]
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	MERGE INTO [dbo].[Orders] T
	USING
	(
		SELECT @Id AS Id
	) S
	ON (T.Id = S.Id)
	WHEN MATCHED THEN
		DELETE;

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END