-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateCoupon]
	@Id UNIQUEIDENTIFIER,
	@OwnerId UNIQUEIDENTIFIER,
	@Code NVARCHAR(50),
	@Description NVARCHAR(255),
	@DiscountAmount NUMERIC(18, 0),
	@DiscountUnit NVARCHAR(50),
	@ApplicableForBrand UNIQUEIDENTIFIER,
	@AppliedToOrder UNIQUEIDENTIFIER,
	@ExpireAt DATETIME2(7)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	MERGE INTO [dbo].[Coupons] T
	USING
	(
		SELECT @Id AS Id,
			   @OwnerId AS OwnerId,
			   @Code AS Code,
			   @Description AS Description,
			   @DiscountAmount AS DiscountAmount,
			   @DiscountUnit AS DiscountUnit,
			   @ApplicableForBrand AS ApplicableForBrand,
			   @AppliedToOrder AS AppliedToOrder,
			   @ExpireAt AS ExpireAt
	) S
	ON (T.Id = S.Id)
	WHEN MATCHED THEN
		UPDATE SET
			[OwnerId] = S.OwnerId,
			[Code] = S.Code,
			[Description] = S.Description,
			[DiscountAmount] = S.DiscountAmount,
			[DiscountUnit] = S.DiscountUnit,
			[ApplicableForBrand] = S.ApplicableForBrand,
			[AppliedToOrder] = S.AppliedToOrder,
			[ExpireAt] = S.ExpireAt;

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END