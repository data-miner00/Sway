-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_IncrementCartItemQuantity]
	@CartItemId UNIQUEIDENTIFIER,
	@Quantity INT = 1
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	MERGE INTO [dbo].[CartItems] T
	USING
	(
		SELECT @CartItemId AS Id, @Quantity AS Quantity
	) S
	ON (T.Id = S.Id AND T.Quantity + S.Quantity >= 0)
	WHEN MATCHED THEN
		UPDATE SET [Quantity] = T.[Quantity] + S.[Quantity];

	COMMIT TRANSACTION

	RETURN @@ERROR;
END