-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteCategoryById]
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	UPDATE [dbo].[Categories]
	SET [ParentId] = NULL
	WHERE [ParentId] = @Id;

	DELETE FROM [dbo].[Categories]
	WHERE [Id] = @Id;

	COMMIT TRANSACTION;
END