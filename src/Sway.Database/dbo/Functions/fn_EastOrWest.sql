-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fn_EastOrWest]
(
	@longitude DECIMAL(9, 6)
)
RETURNS CHAR(4)
AS
BEGIN
	DECLARE @result CHAR(4) = 'same';
	IF (@longitude > 0.00) SET @result = 'east';
	IF (@longitude < 0.00) SET @result = 'west';

	RETURN @result;
END