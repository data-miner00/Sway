WITH firstPaymentMethod AS (
	SELECT TOP 1 * FROM [dbo].[PaymentMethods]
)
UPDATE firstPaymentMethod SET [IsDefault] = 1;