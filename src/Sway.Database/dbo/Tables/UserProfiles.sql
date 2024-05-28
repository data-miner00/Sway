CREATE TABLE [dbo].[UserProfiles] (
    [Id]                NVARCHAR (50)  NOT NULL,
    [Email]             NVARCHAR (50)  NOT NULL,
    [Phone]             NVARCHAR (50)  NULL,
    [PhotoUrl]          NVARCHAR (255) NULL,
    [Description]       NVARCHAR (255) NULL,
    [ShippingAddressId] NVARCHAR (50)  NOT NULL,
    [BillingAddressId]  NVARCHAR (50)  NULL,
    [CreatedAt]         DATETIME2 (7)  NOT NULL,
    [ModifiedAt]        DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

