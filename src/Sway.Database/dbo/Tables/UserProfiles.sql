CREATE TABLE [dbo].[UserProfiles] (
    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_UserProfiles_Id] DEFAULT NEWID() NOT NULL,
    [Email]             NVARCHAR (50)  CONSTRAINT [UQ_UserProfiles_Email] UNIQUE NOT NULL,
    [Phone]             NVARCHAR (50)  CONSTRAINT [UQ_UserProfiles_Phone] UNIQUE NULL,
    [PhotoUrl]          NVARCHAR (255) NULL,
    [Description]       NVARCHAR (255) NULL,
    [ShippingAddressId] UNIQUEIDENTIFIER  NOT NULL,
    [BillingAddressId]  UNIQUEIDENTIFIER  NULL,
    [CreatedAt]         DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]        DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_UserProfiles_Addresses_ShippingAddress] FOREIGN KEY ([ShippingAddressId]) REFERENCES [Addresses]([Id]),
    CONSTRAINT [FK_UserProfiles_Addresses_BillingAddress] FOREIGN KEY ([BillingAddressId]) REFERENCES [Addresses]([Id]),
);

