-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddCoupon]
	@Code NVARCHAR(50),
	@Description NVARCHAR(255),
	@DiscountAmount NUMERIC(18, 0),
	@DiscountUnit NVARCHAR(50),
	@ApplicableForBrand UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	INSERT INTO [dbo].[Coupons]
	(
		[Code],
		[Description],
		[DiscountAmount],
		[DiscountUnit],
		[ApplicableForBrand]
	)
	VALUES
	(
		@Code,
		@Description,
		@DiscountAmount,
		@DiscountUnit,
		@ApplicableForBrand
	);

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END