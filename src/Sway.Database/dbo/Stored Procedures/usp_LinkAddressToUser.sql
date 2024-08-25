-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_LinkAddressToUser]
	@AddressId UNIQUEIDENTIFIER,
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @ProfileId UNIQUEIDENTIFIER;
	DECLARE @Type NVARCHAR(50);

	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRAN
		
		SELECT
			@ProfileId = [ProfileId]
		FROM [dbo].[Users]
		WHERE [Id] = @UserId;

		SELECT @Type = [Type]
		FROM [dbo].[Addresses]
		WHERE [Id] = @AddressId;

		IF @Type = 'Shipping'
		BEGIN
			PRINT 'Insert for Shipping Address';
			UPDATE [dbo].[UserProfiles]
			SET [ShippingAddressId] = @AddressId
			WHERE [Id] = @ProfileId;
		END
		ELSE
		BEGIN
			PRINT 'Insert for Billing Address';
			UPDATE [dbo].[UserProfiles]
			SET [BillingAddressId] = @AddressId
			WHERE [Id] = @ProfileId;
		END

	COMMIT TRAN
END