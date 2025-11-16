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
		UPDATE [dbo].[Products] WITH (ROWLOCK)
		SET [InStock] = [InStock] + @ByAmount
		WHERE [Id] = @ProductId;
	ELSE 
		UPDATE [dbo].[Products] WITH (ROWLOCK)
		SET [InStock] = [InStock] - @ByAmount
		WHERE [Id] = @ProductId;

	COMMIT TRANSACTION

	RETURN @@ERROR;
END