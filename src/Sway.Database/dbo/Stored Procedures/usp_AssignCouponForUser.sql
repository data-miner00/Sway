-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AssignCouponForUser]
	@UserId UNIQUEIDENTIFIER,
	@CouponId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	IF @UserId IS NOT NULL
	   AND EXISTS
	(
		SELECT 1
		FROM [dbo].[Users]
		WHERE [Id] = @UserId
	)
	   AND EXISTS
	(
		SELECT 1
		FROM [dbo].[Coupons]
		WHERE [Id] = @CouponId
			  AND [OwnerId] = NULL
	)
	BEGIN
		UPDATE [dbo].[Coupons]
		SET [OwnerId] = @UserId
		WHERE [Id] = @CouponId;
	END
	ELSE
	BEGIN
		PRINT N'The user or coupon does not exist, or the coupon already owned.';
	END

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END