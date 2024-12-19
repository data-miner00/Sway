-- Truncate a table that contains references from other table.
-- Solution: Drop constraint > Truncate > Add constraint
-- Reference: https://stackoverflow.com/a/253858
-- Since I wont need these two column anyways, I won't add back the constraint

ALTER TABLE UserProfiles DROP CONSTRAINT [FK_UserProfiles_Addresses_ShippingAddress];
ALTER TABLE UserProfiles DROP CONSTRAINT [FK_UserProfiles_Addresses_BillingAddress];
TRUNCATE TABLE Addresses;

GO

-- Face this issue again today while trying truncating Order table
DELETE FROM [Sway].[dbo].[Orders];
DBCC CHECKIDENT ('[Sway].[dbo].[Orders]', RESEED, 0);

GO
