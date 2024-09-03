-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddOrder]
	@UserId UNIQUEIDENTIFIER,
	@Status NVARCHAR(50),
	@TotalAmount MONEY,
	@Currency NVARCHAR(50),
	@PaymentInfoId UNIQUEIDENTIFIER
	-- TODO: Add order address parameter here
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	INSERT INTO [dbo].[Orders]
	(
		[UserId],
		[Status],
		[TotalAmount],
		[Currency],
		[PaymentInfoId]
	)
	VALUES
	(
		@UserId,
		@Status,
		@TotalAmount,
		@Currency,
		@PaymentInfoId
	);

	COMMIT TRANSACTION;
END