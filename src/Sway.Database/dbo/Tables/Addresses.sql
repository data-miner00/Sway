CREATE TABLE [dbo].[Addresses] (
    [Id]         NVARCHAR (50)  NOT NULL,
    [Type]       NVARCHAR (50)  NOT NULL,
    [Street1]    NVARCHAR (255) NOT NULL,
    [Street2]    NVARCHAR (255) NULL,
    [City]       NVARCHAR (50)  NOT NULL,
    [State]      NVARCHAR (50)  NOT NULL,
    [Postcode]   NVARCHAR (50)  NOT NULL,
    [Country]    NVARCHAR (50)  NOT NULL,
    [CreatedAt]  DATETIME2 (7)  NOT NULL,
    [ModifiedAt] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

