-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteBrandById]
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	MERGE INTO [dbo].[Brands] AS T
	USING (SELECT @Id AS Id) AS S
	ON (T.Id = S.Id)
	WHEN MATCHED THEN
		DELETE;

	COMMIT TRANSACTION;
END