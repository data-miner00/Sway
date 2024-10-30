-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_MarkNotificationsForUserAsUnread]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Notifications]
	SET
		[ReadAt] = NULL
	WHERE
		[UserId] = @UserId;
	
	RETURN @@ERROR;
END