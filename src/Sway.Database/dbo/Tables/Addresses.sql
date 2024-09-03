CREATE TABLE [dbo].[Addresses] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_Addresses_Id] NOT NULL DEFAULT NEWSEQUENTIALID() ROWGUIDCOL,
    [Type]       NVARCHAR (50)  NOT NULL,
    [Street1]    NVARCHAR (255) NOT NULL,
    [Street2]    NVARCHAR (255) NULL,
    [City]       NVARCHAR (50)  NOT NULL,
    [State]      NVARCHAR (50)  NOT NULL,
    [Postcode]   NVARCHAR (50)  NOT NULL,
    [Country]    NVARCHAR (50)  NOT NULL,
    [CreatedAt]  DATETIME2 (7)  NOT NULL DEFAULT GETDATE(),
    [ModifiedAt] DATETIME2 (7)  NOT NULL DEFAULT GETDATE(),
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [IsDefault] BIT NULL DEFAULT 0, 
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Addresses_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
        ON DELETE CASCADE ON UPDATE CASCADE
);


GO

CREATE TRIGGER [dbo].[Trigger_Addresses_OnUpdate]
    ON [dbo].[Addresses]
    AFTER UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;

        UPDATE [dbo].[Addresses]
        SET [ModifiedAt] = GETDATE()
        FROM [dbo].[Addresses] T
        INNER JOIN inserted I ON T.Id = I.Id;
    END;