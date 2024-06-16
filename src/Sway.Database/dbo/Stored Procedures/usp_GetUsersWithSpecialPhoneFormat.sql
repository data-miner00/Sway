-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetUsersWithSpecialPhoneFormat]
	@PhoneFormat NVARCHAR(50) = '___-___-____'
AS
BEGIN
	SET NOCOUNT ON;

    SELECT * FROM [dbo].[Users] usr
	INNER JOIN [dbo].[UserProfiles] usrp
	ON usr.ProfileId = usrp.Id
	WHERE usrp.Phone NOT LIKE @PhoneFormat;
END