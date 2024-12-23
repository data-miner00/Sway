WITH cte AS (
	SELECT *,
		ROW_NUMBER() OVER (PARTITION BY [Id], [Currency], [ModifiedAt]) RowNumber
	FROM [dbo].[SystemSetting]
)
DELETE FROM cte
WHERE RowNumber > 1;

