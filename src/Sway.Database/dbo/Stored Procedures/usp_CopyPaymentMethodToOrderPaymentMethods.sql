-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CopyPaymentMethodToOrderPaymentMethods]
	@OrderId UNIQUEIDENTIFIER,
	@PaymentMethodId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	INSERT INTO [dbo].[OrderPaymentMethods]
	(
	    [OrderId]
       ,[Type]
       ,[Provider]
       ,[CVV]
       ,[ExpiryDate]
       ,[CardholderName]
       ,[CardNumber]
       ,[WalletAddress]
       ,[CardIssuingCountry]
       ,[CardIssuingBank]
       ,[Currency]
       ,[Balance]
	)
	SELECT 
		@OrderId OrderId
	   ,[Type]
       ,[Provider]
       ,[CVV]
       ,[ExpiryDate]
       ,[CardholderName]
       ,[CardNumber]
       ,[WalletAddress]
       ,[CardIssuingCountry]
       ,[CardIssuingBank]
       ,[Currency]
       ,[Balance]
	FROM [dbo].[PaymentMethods]
	WHERE [Id] = @PaymentMethodId;

	COMMIT TRANSACTION
END