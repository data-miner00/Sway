﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetUserCartItemDetails] 
	@UserId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @CartId UNIQUEIDENTIFIER;

	SELECT @CartId = [CartId]
	FROM [dbo].[Users]
	WHERE [Id] = @UserId;
    
	SELECT 
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
	WHERE c.ShoppingCartId = @CartId
	AND c.IsDeleted != 1;
END