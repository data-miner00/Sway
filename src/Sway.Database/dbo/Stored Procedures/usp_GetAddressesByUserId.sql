-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAddressesByUserId] 
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @ProfileId UNIQUEIDENTIFIER;
	DECLARE @AddressIds TABLE ([Id] UNIQUEIDENTIFIER);

	SET NOCOUNT ON;

    SELECT
		@ProfileId = [ProfileId]
	FROM [dbo].[Users]
	WHERE [Id] = @UserId;

	IF (@ProfileId IS NULL)
		PRINT 'Profile Is Null'
	ELSE
		INSERT INTO @AddressIds
		SELECT
			[ShippingAddressId]
		FROM [dbo].[UserProfiles]
		WHERE [Id] = @ProfileId
		AND [ShippingAddressId] IS NOT NULL;

		INSERT INTO @AddressIds
		SELECT
			[BillingAddressId]
		FROM [dbo].[UserProfiles]
		WHERE [Id] = @ProfileId
		AND [BillingAddressId] IS NOT NULL;

		SELECT * FROM [dbo].[Addresses]
		WHERE [Id] IN (SELECT * FROM @AddressIds);
END