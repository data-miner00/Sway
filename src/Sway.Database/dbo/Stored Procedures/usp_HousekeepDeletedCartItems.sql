-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_HousekeepDeletedCartItems] 
AS
BEGIN
	DECLARE @OutputTable TABLE (Id UNIQUEIDENTIFIER);

	SET NOCOUNT, XACT_ABORT ON;

	BEGIN TRANSACTION

    DELETE FROM [dbo].[CartItems]
	OUTPUT deleted.Id INTO @OutputTable
	WHERE [IsDeleted] = 1;
	
	COMMIT TRANSACTION

	SELECT * FROM @OutputTable;
END