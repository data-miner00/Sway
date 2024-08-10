-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UndoDeletedCartItem] 
	@CartItemId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [dbo].[CartItems]
	SET [IsDeleted] = 0
	WHERE [Id] = @CartItemId;
END