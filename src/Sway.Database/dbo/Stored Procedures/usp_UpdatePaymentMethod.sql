-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	Updates the payment method.
--				The owner cannot be updated.
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdatePaymentMethod]
    @Id UNIQUEIDENTIFIER,
    @Type NVARCHAR(50),
    @Provider NVARCHAR(50),
    @CVV INT,
    @ExpiryDate DATETIME2(7),
    @CardholderName NVARCHAR(50),
    @CardNumber NVARCHAR(50),
    @WalletAddress NVARCHAR(255),
    @CardIssuingCountry NVARCHAR(50),
    @CardIssuingBank NVARCHAR(50),
    @Currency NVARCHAR(50),
    @Balance MONEY,
    @IsDefault BIT
AS
BEGIN
    SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

    UPDATE [dbo].[PaymentMethods]
    SET
        [Type] = @Type,
        [Provider] = @Provider,
        [CVV] = @CVV,
        [ExpiryDate] = @ExpiryDate,
        [CardholderName] = @CardholderName,
        [CardNumber] = @CardNumber,
        [CardIssuingCountry] = @CardIssuingCountry,
        [CardIssuingBank] = @CardIssuingBank,
        [WalletAddress] = @WalletAddress,
        [Currency] = @Currency,
        [Balance] = @Balance,
        [IsDefault] = @IsDefault

    WHERE [Id] = @Id;

    COMMIT TRANSACTION

    RETURN @@ERROR;
END