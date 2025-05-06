-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SearchProducts]
	@Query NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Products]
	WHERE [Name] LIKE '%' + @Query + '%'
	OR [Description] LIKE '%' + @Query + '%';

	RETURN @@ERROR;
END