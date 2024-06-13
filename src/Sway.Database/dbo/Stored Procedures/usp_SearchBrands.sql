-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SearchBrands]
	@Keyword NVARCHAR(50),
	@Count INT = 5
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP(@Count) * FROM [dbo].[Brands]
	WHERE [Name] LIKE '%' + @Keyword + '%'
	OR [Description] LIKE '%' + @Keyword + '%';

	RETURN @@ERROR;
END