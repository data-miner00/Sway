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
	@OrderLines [dbo].[typ_OrderLines] READONLY
AS
BEGIN
	DECLARE @Outputs TABLE
	(
		[Id] UNIQUEIDENTIFIER
	);

	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION;

	INSERT INTO [dbo].[Orders]
	(
		[UserId],
		[Status],
		[TotalAmount],
		[Currency]
	)
	OUTPUT inserted.Id INTO @Outputs
	VALUES
	(
		@UserId,
		@Status,
		@TotalAmount,
		@Currency
	);

	INSERT INTO [dbo].[OrderItems]
	(
		[OrderId],
		[ProductId],
		[Quantity],
		[UnitPrice],
		[TotalPrice]
	)
	SELECT
		(SELECT TOP 1 [Id] FROM @Outputs),
		[ProductId],
		[Quantity],
		[UnitPrice],
		[TotalPrice]
	FROM @OrderLines;

	COMMIT TRANSACTION;
END