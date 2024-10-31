CREATE TABLE [dbo].[Notifications] (
    [Id]        INT              NOT NULL IDENTITY,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [Type]      NVARCHAR (50)    NOT NULL,
    [Message]   NVARCHAR (255)   NOT NULL,
    [Url]       NVARCHAR (255)   NULL,
    [Priority]  NVARCHAR (50)    NOT NULL,
    [Icon]      NVARCHAR (50)    NULL,
    [RelatedId] NVARCHAR (50)    NULL,
    [CreatedAt] DATETIME2 (7)    NOT NULL DEFAULT GETDATE(),
    [ReadAt]    DATETIME2 (7)    NULL,
    CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Notifications_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

