-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddPaymentMethod]
    @UserId UNIQUEIDENTIFIER,
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

    INSERT INTO [dbo].[PaymentMethods]
    (
        [UserId],
        [Type],
        [Provider],
        [CVV],
        [ExpiryDate],
        [CardholderName],
        [CardNumber],
        [CardIssuingCountry],
        [CardIssuingBank],
        [WalletAddress],
        [Currency],
        [Balance],
        [IsDefault]
    )
    VALUES
    (
        @UserId,
        @Type,
        @Provider,
        @CVV,
        @ExpiryDate,
        @CardholderName,
        @CardNumber,
        @CardIssuingCountry,
        @CardIssuingBank,
        @WalletAddress,
        @Currency,
        @Balance,
        @IsDefault
    );

    COMMIT TRANSACTION

    RETURN @@ERROR;
END