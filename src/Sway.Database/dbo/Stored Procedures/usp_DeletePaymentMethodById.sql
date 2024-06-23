-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeletePaymentMethodById]
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	DELETE FROM [dbo].[PaymentMethods]
	WHERE [Id] = @Id;

	COMMIT TRANSACTION

	RETURN @@ERROR;
END