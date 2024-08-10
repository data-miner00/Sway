-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SoftDeleteCartItem] 
	@CartItemId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[CartItems]
	SET [IsDeleted] = 1
	WHERE [Id] = @CartItemId;
END