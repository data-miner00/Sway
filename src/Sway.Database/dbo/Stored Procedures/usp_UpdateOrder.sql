-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateOrder]
	@Id UNIQUEIDENTIFIER,
	@UserId UNIQUEIDENTIFIER,
	@Status NVARCHAR(50),
	@TotalAmount MONEY,
	@Currency NVARCHAR(50),
	@PaymentInfoId UNIQUEIDENTIFIER,
	@ShippingAddressId UNIQUEIDENTIFIER,
	@BillingAddressId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	MERGE INTO [dbo].[Orders] T
	USING
	(
		SELECT @Id AS Id,
			   @UserId UserId,
			   @TotalAmount TotalAmount,
			   @Currency Currency,
			   @PaymentInfoId PaymentInfoId,
			   @ShippingAddressId ShippingAddressId,
			   @BillingAddressId BillingAddressId
	) S
	ON (T.Id = S.Id)
	WHEN MATCHED THEN
		UPDATE SET
			[UserId] = S.UserId,
			[TotalAmount] = S.TotalAmount,
			[Currency] = S.Currency,
			[PaymentInfoId] = S.PaymentInfoId,
			[ShippingAddressId] = S.ShippingAddressId,
			[BillingAddressId] = S.BillingAddressId;

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END