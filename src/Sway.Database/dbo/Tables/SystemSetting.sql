CREATE TABLE [dbo].[SystemSetting] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_SystemSetting_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [Currency] NVARCHAR (50) NOT NULL,
    [ModifiedAt] DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_SystemSetting] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TRIGGER [dbo].[Trigger_SystemSetting_OnUpdate]
	ON [dbo].[SystemSetting]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[SystemSetting]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[SystemSetting] T
		INNER JOIN inserted I ON T.ID = I.ID;    
	END;
