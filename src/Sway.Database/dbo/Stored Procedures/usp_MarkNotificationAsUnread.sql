-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_MarkNotificationAsUnread]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Notifications]
	SET
		[ReadAt] = NULL
	WHERE
		[Id] = @Id;
	
	RETURN @@ERROR;
END