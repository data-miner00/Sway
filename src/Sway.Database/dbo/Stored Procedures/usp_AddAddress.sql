-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_AddAddress
	@UserId UNIQUEIDENTIFIER,
	@Type NVARCHAR(50),
	@Street1 NVARCHAR(255),
	@Street2 NVARCHAR(255),
	@City NVARCHAR(50),
	@State NVARCHAR(50),
	@Postcode NVARCHAR(50),
	@Country NVARCHAR(50),
	@IsDefault BIT
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRANSACTION;

	INSERT INTO [dbo].[Addresses]
	(
		[Type],
		[Street1],
		[Street2],
		[City],
		[State],
		[Postcode],
		[Country],
		[UserId],
		[IsDefault]
	)
	VALUES
	(
		@Type,
		@Street1,
		@Street2,
		@City,
		@State,
		@Postcode,
		@Country,
		@UserId,
		@IsDefault
	);

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END