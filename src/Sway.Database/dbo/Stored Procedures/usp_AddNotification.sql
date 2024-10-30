-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddNotification]
	@UserId UNIQUEIDENTIFIER,
	@Type NVARCHAR(50),
	@Message NVARCHAR(255),
	@Url NVARCHAR(255),
	@Priority NVARCHAR(50),
	@Icon NVARCHAR(50),
	@RelatedId NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

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
	VALUES
	(
		@UserId,
		@Type,
		@Message,
		@Url,
		@Priority,
		@Icon,
		@RelatedId
	);

END