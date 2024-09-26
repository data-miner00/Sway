-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SetPaymentMethodAsDefaultForUser]
	@UserId UNIQUEIDENTIFIER,
	@PaymentMethodId UNIQUEIDENTIFIER,
	@Verbose BIT = 0
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRAN

	-- Reset all payment methods for user to non-default first
	IF @Verbose = 1
	BEGIN
		DECLARE @PaymentId UNIQUEIDENTIFIER;
		DECLARE PaymentMethodCursor CURSOR FOR
		SELECT [Id] FROM [dbo].[PaymentMethods]
		WHERE [UserId] = @UserId;

		OPEN PaymentMethodCursor;

		FETCH NEXT FROM PaymentMethodCursor INTO @PaymentId;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT 'Unsetting default for ' + CAST(@PaymentId AS NVARCHAR(100));

			UPDATE [dbo].[PaymentMethods]
			SET [IsDefault] = 0
			WHERE [Id] = @PaymentId;

			FETCH NEXT FROM PaymentMethodCursor INTO @PaymentId;
		END
	END
	ELSE
	BEGIN
		UPDATE [dbo].[PaymentMethods]
		SET
			[IsDefault] = 0
		WHERE
			[UserId] = @UserId;
	END


	-- Set the targeted payment method as default
	UPDATE [dbo].[PaymentMethods]
	SET
		[IsDefault] = 1
	WHERE
		[Id] = @PaymentMethodId;

	COMMIT TRAN
END