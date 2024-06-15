-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddCouponForUser]
	@UserId UNIQUEIDENTIFIER,
	@Code NVARCHAR(50),
	@Description NVARCHAR(255),
	@DiscountAmount NUMERIC(18, 0),
	@DiscountUnit NVARCHAR(50),
	@ApplicableForBrand UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	IF @UserId IS NOT NULL AND EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [Id] = @UserId)
	BEGIN
		INSERT INTO [dbo].[Coupons]
		(
			[OwnerId],
			[Code],
			[Description],
			[DiscountAmount],
			[DiscountUnit],
			[ApplicableForBrand]
		)
		VALUES
		(
			@UserId,
			@Code,
			@Description,
			@DiscountAmount,
			@DiscountUnit,
			@ApplicableForBrand
		);
	END
	ELSE IF @UserId IS NULL
	BEGIN
		PRINT N'The UserId provided is NULL';
	END
	ELSE
	BEGIN
		PRINT N'The user does not exist';
	END

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END