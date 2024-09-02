CREATE TABLE [dbo].[Brands] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_Brands_Id] DEFAULT NEWID() NOT NULL,
    [Name]        NVARCHAR (50)  CONSTRAINT [UQ_Brands_Name] UNIQUE NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [LogoUrl]     NVARCHAR (255) NULL,
    [CreatedAt]   DATETIME2 (7)  DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]  DATETIME2 (7)  DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TRIGGER [dbo].[Trigger_Brands_OnUpdate]
	ON [dbo].[Brands]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[Brands]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[Brands] T
		INNER JOIN inserted I ON T.Id = I.Id;
	END;

