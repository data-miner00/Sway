CREATE TABLE [dbo].[ProductRatings]
(
	[Id] INT NOT NULL IDENTITY, 
    [ProductId] UNIQUEIDENTIFIER NOT NULL, 
    [AuthorId] UNIQUEIDENTIFIER NOT NULL, 
    [Rating] INT NOT NULL DEFAULT 0, 
    [Comment] NVARCHAR(255) NULL, 
    [MediaAttachedCount] INT NOT NULL DEFAULT 0, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [ModifiedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_ProductRatings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]),
    CONSTRAINT [FK_Users] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id]),
);

GO

CREATE TRIGGER [dbo].[Trigger_ProductRatings_OnUpdate]
	ON [dbo].[ProductRatings]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[ProductRatings]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[ProductRatings] T
		INNER JOIN inserted I ON T.Id = I.Id;
	END;


