-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_MarkNotificationsAsRead]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Notifications]
	SET
		[ReadAt] = GETDATE()
	WHERE
		[Id] = @Id;
	
	RETURN @@ERROR;
END