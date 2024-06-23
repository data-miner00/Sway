-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdatePaymentMethod]
	@Id UNIQUEIDENTIFIER,
	@UserId UNIQUEIDENTIFIER,
	@Type NVARCHAR(50),
	@Provider NVARCHAR(50),
	@AccountNo NVARCHAR(50),
	@ExpiryDate DATETIME2(7)
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	UPDATE [dbo].[PaymentMethods]
	SET
		[UserId] = @UserId,
		[Type] = @Type,
		[Provider] = @Provider,
		[AccountNo] = @AccountNo,
		[ExpiryDate] = @ExpiryDate

	WHERE [Id] = @Id;

	COMMIT TRANSACTION

	RETURN @@ERROR;
END