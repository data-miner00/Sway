-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateAddress]
	@Id UNIQUEIDENTIFIER,
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
	SET NOCOUNT, XACT_ABORT ON;

	BEGIN TRANSACTION;

	UPDATE [dbo].[Addresses]
	SET
		[Type] = @Type,
		[Street1] = @Street1,
		[Street2] = @Street2,
		[City] = @City,
		[State] = @State,
		[Postcode] = @Postcode,
		[Country] = @Country,
		[IsDefault] = @IsDefault
	WHERE [Id] = @Id;

	COMMIT TRANSACTION;

	RETURN @@ERROR;
END