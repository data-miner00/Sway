CREATE TABLE [dbo].[Products] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_Products_Id] DEFAULT NEWSEQUENTIALID() NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [Price]       MONEY          NOT NULL,
    [InStock]     INT            NOT NULL,
    [SKU]         NVARCHAR (255) NULL,
    [BrandId]     UNIQUEIDENTIFIER NOT NULL,
    [CategoryId]  UNIQUEIDENTIFIER NULL,
    [CreatedAt]   DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [ModifiedAt]  DATETIME2 (7) DEFAULT GETDATE() NOT NULL,
    [AverageRatings] FLOAT NOT NULL DEFAULT 0.0, 
    [UnitsSold] INT NOT NULL DEFAULT 0, 
    [DeliveryTime] NVARCHAR(50) NULL, 
    [Favourite] INT NOT NULL DEFAULT 0, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Products_Price_Positive] CHECK ([Price] > 0),
    CONSTRAINT [CK_Products_InStock_Positive] CHECK ([InStock] > 0), 
    CONSTRAINT [FK_Products_Brands] FOREIGN KEY ([BrandId]) REFERENCES [Brands]([Id]), 
    CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]),
);


GO

CREATE TRIGGER [dbo].[Trigger_Products_OnUpdate]
	ON [dbo].[Products]
	AFTER UPDATE
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [dbo].[Products]
		SET [ModifiedAt] = GETDATE()
		FROM [dbo].[Products] T
		INNER JOIN inserted I ON T.Id = I.Id;
	END;
