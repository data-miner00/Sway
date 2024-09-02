-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeselectCartItem] 
	@CartItemId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[CartItems]
	SET
		[IsSelected] = 0
	WHERE
		[Id] = @CartItemId;
END