-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetSpecificPaymentMethods]
	@Providers [dbo].[typ_PaymentProviders] READONLY
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @RowCount INT;

	SELECT
		@RowCount = COUNT(*)
	FROM @Providers;

	IF @RowCount > 0
	BEGIN
		SELECT * FROM [dbo].[PaymentMethods]
		WHERE [Provider] IN (SELECT [ProviderName] FROM @Providers);
	END
	ELSE
	BEGIN
		SELECT * FROM [dbo].[PaymentMethods]
		WHERE [Provider] IN
		(
			N'PayPal',
			N'RazerPay'
		)
		OPTION
		(
			USE HINT('QUERY_OPTIMIZER_COMPATIBILITY_LEVEL_140')
		);
	END
END