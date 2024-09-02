CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER CONSTRAINT [DF_Users_Id] DEFAULT NEWID() NOT NULL,
    [Username]     NVARCHAR (50) CONSTRAINT [UQ_Users_Username] UNIQUE NOT NULL,
    [Status]       NVARCHAR (50) NOT NULL,
    [ProfileId]    UNIQUEIDENTIFIER NOT NULL,
    [CredentialId] UNIQUEIDENTIFIER NOT NULL,
    [CartId]       UNIQUEIDENTIFIER NULL,
    [Role]         NVARCHAR (50) NOT NULL,
    [DateOfBirth]  DATETIME2 (7) NOT NULL,
    [CreatedAt]    DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]   DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Users_UserProfiles] FOREIGN KEY ([ProfileId]) REFERENCES [UserProfiles]([Id])
		ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_Users_Credentials] FOREIGN KEY ([CredentialId]) REFERENCES [Credentials]([Id])
        ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_Users_ShoppingCarts] FOREIGN KEY ([CartId]) REFERENCES [ShoppingCarts]([Id])
        ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [CK_Users_DateOfBirth_NotInFuture] CHECK ([DateOfBirth] < GETDATE())
);


GO

CREATE INDEX [IX_Users_Username] ON [dbo].[Users] ([Username]);


GO

CREATE TRIGGER [dbo].[Trigger_Users_OnUpdate]
	ON [dbo].[Users]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[Users]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[Users] T
        INNER JOIN inserted I ON T.Id = I.Id;
	END;
