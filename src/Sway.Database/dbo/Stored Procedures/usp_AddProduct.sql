-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddProduct]
	@Name NVARCHAR(50),
	@Description NVARCHAR(255),
	@Price MONEY,
	@InStock INT,
	@SKU NVARCHAR(255),
	@BrandId UNIQUEIDENTIFIER,
	@CategoryId UNIQUEIDENTIFIER,
	@DeliveryTime NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	INSERT INTO [dbo].[Products]
	(
		[Name],
		[Description],
		[Price],
		[InStock],
		[SKU],
		[BrandId],
		[CategoryId],
		[DeliveryTime]
	)
	VALUES
	(
		@Name,
		@Description,
		@Price,
		@InStock,
		@SKU,
		@BrandId,
		@CategoryId,
		@DeliveryTime
	);

	COMMIT TRANSACTION
END