CREATE TABLE [dbo].[Addresses] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF__Addresses__Id__408F9238] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [Type]       NVARCHAR (50)    NOT NULL,
    [Street1]    NVARCHAR (255)   NOT NULL,
    [Street2]    NVARCHAR (255)   NULL,
    [City]       NVARCHAR (50)    NOT NULL,
    [State]      NVARCHAR (50)    NOT NULL,
    [Postcode]   NVARCHAR (50)    NOT NULL,
    [Country]    NVARCHAR (50)    NOT NULL,
    [CreatedAt]  DATETIME2 (7)    CONSTRAINT [DF__Addresses__Creat__4183B671] DEFAULT (getdate()) NOT NULL,
    [ModifiedAt] DATETIME2 (7)    CONSTRAINT [DF__Addresses__Modif__4277DAAA] DEFAULT (getdate()) NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [IsDefault]  BIT              CONSTRAINT [DF__Addresses__IsDef__314D4EA8] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Addresses_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
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