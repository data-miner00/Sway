-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddBrand]
	@Name NVARCHAR(50),
	@Description NVARCHAR(255),
	@LogoUrl NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	INSERT INTO [dbo].[Brands]
	(
		[Name],
		[Description],
		[LogoUrl]
	)
	VALUES
	(
		@Name,
		@Description,
		@LogoUrl
	);

	COMMIT TRANSACTION;
END