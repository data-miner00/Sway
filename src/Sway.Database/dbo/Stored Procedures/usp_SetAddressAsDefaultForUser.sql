-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SetAddressAsDefaultForUser]
	@UserId UNIQUEIDENTIFIER,
	@AddressId UNIQUEIDENTIFIER,
	@Verbose BIT = 0
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRAN

	-- Reset all address for user to non-default first
	IF @Verbose = 1
	BEGIN
		DECLARE @CurrentAddressId UNIQUEIDENTIFIER;
		DECLARE AddressCursor CURSOR STATIC FOR
		SELECT [Id] FROM [dbo].[Addresses]
		WHERE [UserId] = @UserId;

		OPEN AddressCursor;

		FETCH NEXT FROM AddressCursor INTO @CurrentAddressId;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT 'Unsetting default for ' + CAST(@CurrentAddressId AS NVARCHAR(100));

			UPDATE [dbo].[Addresses]
			SET [IsDefault] = 0
			WHERE [Id] = @AddressId;

			FETCH NEXT FROM AddressCursor INTO @CurrentAddressId;
		END

		CLOSE AddressCursor;
		DEALLOCATE AddressCursor;
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Addresses]
		SET
			[IsDefault] = 0
		WHERE
			[UserId] = @UserId;
	END

	-- Set the targeted address as default
	UPDATE [dbo].[Addresses]
	SET
		[IsDefault] = 1
	WHERE
		[Id] = @AddressId;

	COMMIT TRAN
END