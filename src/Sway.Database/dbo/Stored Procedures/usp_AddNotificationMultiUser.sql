-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddNotificationMultiUser]
	@UserIdList NVARCHAR(MAX),
	@Type NVARCHAR(50),
	@Message NVARCHAR(255),
	@Url NVARCHAR(255),
	@Priority NVARCHAR(50),
	@Icon NVARCHAR(50),
	@RelatedId NVARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRAN

	INSERT INTO [dbo].[Notifications]
	(
		[UserId],
		[Type],
		[Message],
		[Url],
		[Priority],
		[Icon],
		[RelatedId]
	)
	SELECT
		TRY_CAST(value AS UNIQUEIDENTIFIER),
		@Type,
		@Message,
		@Url,
		@Priority,
		@Icon,
		@RelatedId
	FROM STRING_SPLIT(@UserIdList, ',')
	WHERE TRY_CAST(value AS UNIQUEIDENTIFIER) IS NOT NULL;

	COMMIT TRAN

	RETURN @@ERROR;
END