-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SearchAddress]
	@Keyword NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 5 * FROM [dbo].[Addresses]
	WHERE [Street1] LIKE '%' + @Keyword + '%'
	OR [Street2] LIKE '%' + @Keyword + '%'
	OR [City] LIKE '%' + @Keyword + '%'
	OR [State] LIKE '%' + @Keyword + '%'
	OR [Postcode] LIKE '%' + @Keyword + '%'
	OR [Country] LIKE '%' + @Keyword + '%';

	RETURN @@ERROR;
END