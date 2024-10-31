-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetNotificationsByUserId]
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
	WHERE [UserId] = @UserId;
	
	RETURN @@ERROR;
END