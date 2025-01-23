-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CopyAddressToOrderAddress]
	@OrderId UNIQUEIDENTIFIER,
	@AddressId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT, XACT_ABORT ON;

    BEGIN TRANSACTION

	INSERT INTO [dbo].[OrderAddresses]
	(
		[Type]
       ,[Street1]
       ,[Street2]
       ,[City]
       ,[State]
       ,[Postcode]
       ,[Country]
       ,[OrderId]	
	)
	SELECT 
		[Type]
	   ,[Street1]
       ,[Street2]
       ,[City]
       ,[State]
       ,[Postcode]
       ,[Country]
       ,@OrderId OrderId	
	FROM [dbo].[Addresses]
	WHERE [Id] = @AddressId;

	COMMIT TRANSACTION
END