-- =============================================
-- Author:		Shaun Chong
-- Create date: 21 October, 2025
-- Description:	Deletes a coupon by Id.
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteCouponById]
	@CouponId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

	BEGIN TRAN
    
	DELETE FROM [dbo].[Coupons]
	WHERE [Id] = @CouponId;

	COMMIT TRAN
END