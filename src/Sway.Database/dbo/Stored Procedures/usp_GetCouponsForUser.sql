-- =============================================
-- Author:		Shaun Chong
-- Create date: 21 October 2025
-- Description:	Gets the coupons for a user with optional flags
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetCouponsForUser]
	@UserId UNIQUEIDENTIFIER,

	-- 0 = All
	-- 1 = Expired only
	-- 2 = Non-expired only
	@IsExpired INT = 0,

	-- 0 = All
	-- 1 = Used only
	-- 2 = Non-used only
	@IsUsed INT = 0
AS
BEGIN
	SET NOCOUNT ON;

	IF @IsExpired = 1 -- Expired only
	BEGIN
		SELECT
			[Id],
			[OwnerId],
			[Code],
			[Description],
			[DiscountAmount],
			[DiscountUnit],
			[ApplicableForBrand],
			[AppliedToOrder],
			[ExpireAt],
			[CreatedAt],
			[ModifiedAt]
		FROM [dbo].[Coupons] WITH (READPAST)
		WHERE [OwnerId] = @UserId
		AND [ExpireAt] < GETUTCDATE();
	END
	ELSE IF @IsExpired = 2 -- Non-expired only
	BEGIN
		SELECT
			[Id],
			[OwnerId],
			[Code],
			[Description],
			[DiscountAmount],
			[DiscountUnit],
			[ApplicableForBrand],
			[AppliedToOrder],
			[ExpireAt],
			[CreatedAt],
			[ModifiedAt]
		FROM [dbo].[Coupons] WITH (READPAST)
		WHERE [OwnerId] = @UserId
		AND [ExpireAt] > GETUTCDATE();
	END
	ELSE -- All
	BEGIN
		IF @IsUsed = 1 -- Used
		BEGIN
			SELECT
				[Id],
				[OwnerId],
				[Code],
				[Description],
				[DiscountAmount],
				[DiscountUnit],
				[ApplicableForBrand],
				[AppliedToOrder],
				[ExpireAt],
				[CreatedAt],
				[ModifiedAt]
			FROM [dbo].[Coupons] WITH (READPAST)
			WHERE [OwnerId] = @UserId
			AND [AppliedToOrder] IS NOT NULL;
		END
		ELSE IF @IsUsed = 2 -- Not-used
		BEGIN
			SELECT
				[Id],
				[OwnerId],
				[Code],
				[Description],
				[DiscountAmount],
				[DiscountUnit],
				[ApplicableForBrand],
				[AppliedToOrder],
				[ExpireAt],
				[CreatedAt],
				[ModifiedAt]
			FROM [dbo].[Coupons] WITH (READPAST)
			WHERE [OwnerId] = @UserId
			AND [AppliedToOrder] IS NULL;
		END
		ELSE -- All
		BEGIN
			SELECT
				[Id],
				[OwnerId],
				[Code],
				[Description],
				[DiscountAmount],
				[DiscountUnit],
				[ApplicableForBrand],
				[AppliedToOrder],
				[ExpireAt],
				[CreatedAt],
				[ModifiedAt]
			FROM [dbo].[Coupons] WITH (READPAST)
			WHERE [OwnerId] = @UserId;
		END
	END
END