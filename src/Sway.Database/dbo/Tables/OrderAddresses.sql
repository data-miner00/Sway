CREATE TABLE [dbo].[OrderAddresses] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_OrderAddresses_Id] NOT NULL DEFAULT NEWSEQUENTIALID() ROWGUIDCOL,
    [Type]       NVARCHAR (50)  NOT NULL,
    [Street1]    NVARCHAR (255) NOT NULL,
    [Street2]    NVARCHAR (255) NULL,
    [City]       NVARCHAR (50)  NOT NULL,
    [State]      NVARCHAR (50)  NOT NULL,
    [Postcode]   NVARCHAR (50)  NOT NULL,
    [Country]    NVARCHAR (50)  NOT NULL,
    [CreatedAt]  DATETIME2 (7)  NOT NULL DEFAULT GETDATE(),
    [ModifiedAt] DATETIME2 (7)  NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [PK_OrderAddresses] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TRIGGER [dbo].[Trigger_OrderAddresses_OnUpdate]
    ON [dbo].[OrderAddresses]
    AFTER UPDATE
    AS
    BEGIN
        SET NOCOUNT ON;

        UPDATE [dbo].[OrderAddresses]
        SET [ModifiedAt] = GETDATE()
        FROM [dbo].[OrderAddresses] T
		INNER JOIN inserted I ON T.Id = I.Id;
    END;