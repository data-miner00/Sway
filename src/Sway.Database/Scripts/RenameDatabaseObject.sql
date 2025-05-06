DECLARE @Execute BIT = 0;

IF @Execute = 1
BEGIN
	-- Rename Table, Stored Procedure, and Trigger
	EXEC sp_rename 'dbo.OrderItems', 'OrderLines';

	-- Rename Column
	EXEC sp_rename 'dbo.OrderItems.Id', 'MyId', 'COLUMN';
END;
