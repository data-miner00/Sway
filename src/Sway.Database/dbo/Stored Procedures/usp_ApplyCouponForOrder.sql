-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ApplyCouponForOrder]
	@OrderId UNIQUEIDENTIFIER,
	@CouponId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	IF @OrderId IS NOT NULL
	   AND EXISTS
	(
		SELECT 1
		FROM [dbo].[Orders]
		WHERE [Id] = @OrderId
	)
	   AND EXISTS
	(
		SELECT 1
		FROM [dbo].[Coupons]
		WHERE [Id] = @CouponId
			  AND [AppliedToOrder] = NULL
	)
	BEGIN
		UPDATE [dbo].[Coupons]
		SET [AppliedToOrder] = @OrderId
		WHERE [Id] = @CouponId;
	END
	ELSE
	BEGIN
		PRINT N'The coupon does not exist, or the coupon already been used.';
	END

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END