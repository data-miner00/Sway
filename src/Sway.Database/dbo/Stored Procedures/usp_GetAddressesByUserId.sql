-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAddressesByUserId] 
	@UserId UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		[Id],
		[Type],
		[Street1],
		[Street2],
		[City],
		[State],
		[Postcode],
		[Country],
		[CreatedAt],
		[ModifiedAt],
		[IsDefault]
	FROM [dbo].[Addresses] WITH (READPAST)
	WHERE [UserId] = @UserId;
END