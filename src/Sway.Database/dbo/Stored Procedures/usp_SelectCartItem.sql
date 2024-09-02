-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_SelectCartItem] 
	@CartItemId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[CartItems]
	SET
		[IsSelected] = 1
	WHERE
		[Id] = @CartItemId;
END