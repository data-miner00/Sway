CREATE TABLE [dbo].[Categories] (
    [Id]          NVARCHAR (50)  NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [ParentId]    NVARCHAR (50)  NULL,
    [CreatedAt]   DATETIME2 (7)  NOT NULL,
    [ModifiedAt]  DATETIME2 (7)  NOT NULL
);

