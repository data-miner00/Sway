-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetSeenNotificationsByUserId]
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
	AND [ReadAt] IS NOT NULL;
	
	RETURN @@ERROR;
END