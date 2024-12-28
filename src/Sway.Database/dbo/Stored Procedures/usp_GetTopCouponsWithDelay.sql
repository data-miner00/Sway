-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[usp_GetTopCouponsWithDelay]
	@Count INT = 1000
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT TOP (@Count)[Id]
      ,[OwnerId]
      ,[Code]
      ,[Description]
      ,[DiscountAmount]
      ,[DiscountUnit]
      ,[ApplicableForBrand]
      ,[AppliedToOrder]
      ,[ExpireAt]
      ,[CreatedAt]
      ,[ModifiedAt]
	FROM [Sway].[dbo].[Coupons] WITH (NOLOCK)
	ORDER BY [CreatedAt] DESC
	WAITFOR DELAY '00:00:10';
END