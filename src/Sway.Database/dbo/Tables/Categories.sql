CREATE TABLE [dbo].[Categories] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_Categories_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [Name]        NVARCHAR (50)  CONSTRAINT [UQ_Categories_Name] UNIQUE NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [ParentId]    UNIQUEIDENTIFIER NULL,
    [CreatedAt]   DATETIME2 (7)  DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]  DATETIME2 (7)  DEFAULT GETDATE() NOT NULL, 
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Categories_Categories] FOREIGN KEY ([ParentId]) REFERENCES [Categories]([Id]),
);


GO

CREATE TRIGGER [dbo].[Trigger_Categories_OnUpdate]
	ON [dbo].[Categories]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[Categories]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[Categories] T
        INNER JOIN inserted I ON T.Id = I.Id;
	END;


