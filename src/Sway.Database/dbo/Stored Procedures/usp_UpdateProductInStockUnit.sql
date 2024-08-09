-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateProductInStockUnit]
	@ProductId UNIQUEIDENTIFIER,
	@ByAmount INT,

	-- If true, increment by the amount. Otherwise, decrement.
	@IsIncrement BIT
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	If @IsIncrement = 1
		UPDATE [dbo].[Products]
		SET [InStock] = [InStock] + @ByAmount;
	ELSE 
		UPDATE [dbo].[Products]
		SET [InStock] = [InStock] - @ByAmount;

	COMMIT TRANSACTION

	RETURN @@ERROR;
END