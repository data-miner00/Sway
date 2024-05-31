-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fn_CalculateAge]
(
	@DateOfBirth DATE
)
RETURNS INT
AS
BEGIN
	DECLARE @Age INT;
	SET @Age
		= DATEDIFF(YEAR, @DateOfBirth, GETDATE())
		  - CASE
				WHEN DATEADD(YEAR, DATEDIFF(YEAR, @DateOfBirth, GETDATE()), @DateOfBirth) > GETDATE() THEN
					1
				ELSE
					0
			END;

	RETURN @Age;
END