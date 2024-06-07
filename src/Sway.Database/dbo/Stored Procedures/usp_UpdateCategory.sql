-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateCategory]
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(50),
	@Description NVARCHAR(255),
	@ParentId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	MERGE INTO [dbo].[Categories] T
	USING (SELECT @Id AS Id,
		@Name AS Name,
		@Description AS Description,
		@ParentId AS ParentId) S
	ON (T.Id = S.Id)
	WHEN MATCHED THEN
		UPDATE SET [Name] = @Name,
			[Description] = @Description,
			[ParentId] = @ParentId;

	COMMIT TRANSACTION;
END