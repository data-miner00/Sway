-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetUserCartItemDetailsSorted] 
	@UserId UNIQUEIDENTIFIER,
	@SortColumn NVARCHAR(50),
	@SortOrder NVARCHAR(4)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @CartId UNIQUEIDENTIFIER;
	DECLARE @SQL NVARCHAR(MAX);

	IF UPPER(@SortOrder) NOT IN ('ASC', 'DESC')
    BEGIN
        SET @SortOrder = 'ASC';
    END

	SELECT @CartId = [CartId]
	FROM [dbo].[Users]
	WHERE [Id] = @UserId;
    
	SET @SQL = 'SELECT 
		c.Id Id,
		p.Name ProductName,
		p.Description ProductDescription,
		p.Id ProductId,
		p.Price UnitPrice,
		c.Quantity Quantity,
		c.IsSelected IsSelected,
		c.CreatedAt AddedAt,
		c.ModifiedAt ModifiedAt
	FROM [dbo].[CartItems] c
	INNER JOIN [dbo].[Products] p
	ON p.Id = c.ProductId
	WHERE c.ShoppingCartId = ''' + CONVERT(NVARCHAR(36), @CartId) + '''
	AND c.IsDeleted != 1
	ORDER BY ' + @SortColumn + ' ' + @SortOrder;

	EXEC sp_sqlexec @SQL;
END