-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetRecentlyAddedProductsByDays]
	@DaysFromToday INT = 30
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Products]
	WHERE DATEDIFF(DAY, [CreatedAt], GETDATE()) BETWEEN 0 AND @DaysFromToday;
END