-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddPaymentMethod]
	@UserId UNIQUEIDENTIFIER,
	@Type NVARCHAR(50),
	@Provider NVARCHAR(50),
	@AccountNo NVARCHAR(50),
	@ExpiryDate DATETIME2(7)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	INSERT INTO [dbo].[PaymentMethods]
	(
		[UserId],
		[Type],
		[Provider],
		[AccountNo],
		[ExpiryDate]
	)
	VALUES
	(
		@UserId,
		@Type,
		@Provider,
		@AccountNo,
		@ExpiryDate
	);

	COMMIT TRANSACTION

	RETURN @@ERROR;
END