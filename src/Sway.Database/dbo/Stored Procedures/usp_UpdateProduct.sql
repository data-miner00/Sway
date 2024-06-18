-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateProduct]
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(50),
	@Description NVARCHAR(255),
	@Price MONEY,
	@InStock INT,
	@SKU NVARCHAR(255),
	@BrandId UNIQUEIDENTIFIER,
	@CategoryId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	UPDATE [dbo].[Products]
	SET
		[Name] = @Name,
		[Description] = @Description,
		[Price] = @Price,
		[InStock] = InStock,
		[SKU] = @SKU,
		[BrandId] = @BrandId,
		[CategoryId] = @CategoryId
	WHERE
		[Id] = @Id;

	COMMIT TRANSACTION
END