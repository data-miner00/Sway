-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetUnreadNotificationsByUserId]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		[Id],
		[UserId],
		[Type],
		[Message],
		[Url],
		[Priority],
		[Icon],
		[RelatedId],
		[CreatedAt],
		[ReadAt]
	FROM [dbo].[Notifications]
	WHERE [UserId] = @UserId
	AND [ReadAt] IS NULL;
	
	RETURN @@ERROR;
END