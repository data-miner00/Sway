-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SetFirstProductName]
	@Name NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    WITH vw_TopOneProduct AS (
		SELECT TOP 1 * FROM
		[dbo].[Products]
	)
	UPDATE vw_TopOneProduct
	SET [Name] = @Name;

END