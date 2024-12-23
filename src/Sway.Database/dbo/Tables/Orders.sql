CREATE TABLE [dbo].[Orders] (
    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_Orders_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [UserId]            UNIQUEIDENTIFIER NOT NULL,
    [Status]            NVARCHAR (50) NOT NULL,
    [TotalAmount]       MONEY         NOT NULL,
    [Currency]          NVARCHAR (50) NOT NULL,
    [CreatedAt]         DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]        DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
        ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [CK_Orders_TotalAmount_Positive] CHECK ([TotalAmount] > 0)
);

GO

CREATE TRIGGER [dbo].[Trigger_Orders_OnUpdate]
	ON [dbo].[Orders]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[Orders]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[Orders] T
		INNER JOIN inserted I ON T.Id = I.Id;
	END;

