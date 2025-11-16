-- This will require the CSV to have all fields populated
-- and cannot take advantage of system generated default values

BULK INSERT [dbo].[Brands]
FROM 'C:\data\Brands.csv'
WITH (
    FIRSTROW = 2, -- Skip header
    FIELDTERMINATOR = ',', 
    ROWTERMINATOR = '\n',
    TABLOCK
);
