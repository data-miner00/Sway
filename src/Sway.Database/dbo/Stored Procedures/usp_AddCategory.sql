-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddCategory]
	@Name NVARCHAR(50),
	@Description NVARCHAR(255),
	@ParentId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    BEGIN TRANSACTION;

	INSERT INTO [dbo].[Categories]
	(
		[Name],
		[Description],
		[ParentId]
	)
	VALUES
	(
		@Name,
		@Description,
		@ParentId
	);

	COMMIT TRANSACTION;
END