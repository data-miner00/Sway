-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ToggleSelectCartItem] 
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[CartItems]
	SET
		[IsSelected] = ~[IsSelected]
	WHERE
		[Id] = @Id;
END