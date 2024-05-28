CREATE TABLE [dbo].[SystemSetting] (
    [Id]       NVARCHAR (50) NOT NULL,
    [Currency] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SystemSetting] PRIMARY KEY CLUSTERED ([Id] ASC)
);

