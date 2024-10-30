-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_MarkNotificationsForUserAsRead]
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Notifications]
	SET
		[ReadAt] = GETDATE()
	WHERE
		[UserId] = @UserId;
	
	RETURN @@ERROR;
END