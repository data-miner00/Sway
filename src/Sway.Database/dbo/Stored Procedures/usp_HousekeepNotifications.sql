-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_HousekeepNotifications]
	@Threshold INT,
	@Unit NVARCHAR(10),
	@KeepUnread BIT = 0
AS
BEGIN
	DECLARE @DateThreshold DATETIME

	SET NOCOUNT ON;

	SET @DateThreshold =
		CASE
			WHEN @Unit = 'day' THEN DATEADD(DAY, -@Threshold, GETDATE())
			WHEN @Unit = 'month' THEN DATEADD(MONTH, -@Threshold, GETDATE())
			WHEN @Unit = 'year' THEN DATEADD(YEAR, -@Threshold, GETDATE())
			ELSE NULL
		END;
	
	IF @DateThreshold IS NOT NULL
	BEGIN
		IF @KeepUnread = 1
		BEGIN
			DELETE FROM [dbo].[Notifications] WITH (TABLOCK)
			WHERE [CreatedAt] < @DateThreshold
			AND [ReadAt] IS NOT NULL;
		END
		ELSE
		BEGIN
			DELETE FROM [dbo].[Notifications] WITH (TABLOCK)
			WHERE [CreatedAt] < @DateThreshold;
		END
	END
	ELSE
	BEGIN;
		THROW 51000, 'Invalid unit provided. Please use "day", "month" or "year" instead.', 1;
	END

	RETURN @@ERROR;
END