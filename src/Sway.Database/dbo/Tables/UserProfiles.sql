CREATE TABLE [dbo].[UserProfiles] (
    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_UserProfiles_Id] DEFAULT NEWID() NOT NULL,
    [Email]             NVARCHAR (50)  CONSTRAINT [UQ_UserProfiles_Email] UNIQUE NOT NULL,
    [Phone]             NVARCHAR (50)  NULL,
    [PhotoUrl]          NVARCHAR (255) NULL,
    [Description]       NVARCHAR (255) NULL,
    [ShippingAddressId] UNIQUEIDENTIFIER  NULL,
    [BillingAddressId]  UNIQUEIDENTIFIER  NULL,
    [CreatedAt]         DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]        DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL , 
    [LastName] NVARCHAR(50) NOT NULL , 
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_UserProfiles_Addresses_ShippingAddress] FOREIGN KEY ([ShippingAddressId]) REFERENCES [Addresses]([Id]),
    CONSTRAINT [FK_UserProfiles_Addresses_BillingAddress] FOREIGN KEY ([BillingAddressId]) REFERENCES [Addresses]([Id]),
);


GO

CREATE TRIGGER [dbo].[Trigger_UserProfiles_OnUpdate]
	ON [dbo].[UserProfiles]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[UserProfiles]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[UserProfiles] T
		INNER JOIN inserted I ON T.Id = I.Id;
	END;

GO

-- Reference: https://stackoverflow.com/questions/767657/how-do-i-create-a-unique-constraint-that-also-allows-nulls
CREATE UNIQUE NONCLUSTERED INDEX IX_UserProfiles_Phone ON [UserProfiles] (Phone) WHERE Phone IS NOT NULL;

