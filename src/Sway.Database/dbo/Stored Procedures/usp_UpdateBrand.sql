-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateBrand]
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(50),
	@Description NVARCHAR(255),
	@LogoUrl NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	MERGE INTO [dbo].[Brands] AS T
	USING (SELECT @Id AS Id,
				  @Name AS Name,
				  @Description AS Description,
				  @LogoUrl AS LogoUrl) AS S
	ON (T.Id = S.Id)
	WHEN MATCHED THEN
		UPDATE SET Name = S.Name,
				   Description = S.Description,
				   LogoUrl = S.LogoUrl;

	COMMIT TRANSACTION;
END