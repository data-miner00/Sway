BEGIN TRANSACTION

DECLARE @Outputs TABLE (
	[Id] UNIQUEIDENTIFIER
);

IF NOT EXISTS (SELECT 1 FROM [dbo].[Brands])
BEGIN

	INSERT INTO [dbo].[Brands]
	(
		[LogoUrl],
		[Description],
		[Name]
	)
	OUTPUT inserted.Id INTO @Outputs
	VALUES
	(
		N'https://upload.wikimedia.org/wikipedia/commons/c/cb/Louis_Vuitton_LV_logo.png',
		N'Louis Vuitton is a world-renowned luxury fashion house known for its exquisite leather goods, iconic monogram designs, and high-quality craftsmanship, embodying elegance and sophistication in every piece.',
		N'Louis Vuitton'
	),
	(
		N'https://upload.wikimedia.org/wikipedia/en/9/92/Chanel_logo_interlocking_cs.svg',
		N'Chanel is a legendary French fashion house celebrated for its timeless elegance, iconic tweed suits, and classic fragrances, especially the iconic No. 5 perfume.',
		N'Chanel'
	),
	(
		N'https://upload.wikimedia.org/wikipedia/commons/c/c5/Gucci_logo.svg',
		N'Gucci is an Italian luxury brand renowned for its bold, eclectic designs and distinctive GG logo, offering high-end fashion, leather goods, and accessories.',
		N'Gucci'
	),
	(
		N'https://upload.wikimedia.org/wikipedia/commons/b/b8/Prada-Logo.svg',
		N'Prada is a prestigious Italian label known for its sophisticated and innovative designs, offering a range of luxurious clothing, handbags, and footwear.',
		N'Prada'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/hermes-logo-vector.svg',
		N'Hermès is a distinguished French brand famous for its exquisite craftsmanship, particularly its coveted Birkin and Kelly bags, and elegant silk scarves.',
		N'Hermès'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/dior-logo.png',
		N'Dior is a French luxury fashion house recognized for its opulent and glamorous designs, iconic fragrances, and the timeless "New Look" silhouette.',
		N'Dior'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/versace-logo-1.png',
		N'Versace is an Italian fashion brand known for its bold, vibrant designs, daring prints, and luxurious apparel that exude a sense of extravagance and glamour.',
		N'Versace'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/balenciaga-logo-black-and-white.png',
		N'Balenciaga is a Spanish luxury fashion house celebrated for its avant-garde and innovative designs, particularly in ready-to-wear and footwear.',
		N'Balenciaga'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/burberry-logo-black-and-white.png',
		N'Burberry is a British luxury brand famous for its iconic trench coats, distinctive check pattern, and classic, timeless designs in fashion and accessories.',
		N'Burberry'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/fendi-logo-black-and-white.png',
		N'Fendi is an Italian luxury brand renowned for its high-quality fur and leather goods, particularly its signature Baguette bags and innovative fashion designs.',
		N'Fendi'
	),
	(
		N'https://upload.wikimedia.org/wikipedia/commons/b/b3/Valentino_logo.svg',
		N'Valentino is an Italian fashion house known for its romantic and glamorous couture, particularly its exquisite evening gowns and signature red dresses.',
		N'Valentino'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/givenchy-logo-1.png',
		N'Givenchy is a French luxury brand recognized for its sophisticated and elegant designs, blending classic styles with modern elements in fashion and haute couture.',
		N'Givenchy'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/yves-saint-laurent-logo.png',
		N'Saint Laurent, also known as Yves Saint Laurent, is a French fashion house celebrated for its chic and edgy designs, including the iconic Le Smoking tuxedo jacket.',
		N'Saint Laurent'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/cartier-logo-black-and-white.png',
		N'Cartier is a prestigious French jeweler and watchmaker renowned for its exquisite and timeless pieces, including the iconic Love bracelet and Tank watch.',
		N'Cartier'
	),
	(
		N'https://brandslogos.com/wp-content/uploads/images/large/tiffany-co-logo.png',
		N'Tiffany & Co. is an American luxury jewelry brand celebrated for its elegant and classic designs, particularly its diamond engagement rings and the iconic Tiffany Blue Box.',
		N'Tiffany & Co.'
	);
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories])
BEGIN
	INSERT INTO [dbo].[Categories]
	(
		[Name],
		[Description]
	)
	VALUES
	(
		N'Dresses',
		N'Dresses'
	),
	(
		N'Tops',
		N'Tops'
	),
	(
		N'Shirts',
		N'Shirts'
	),
	(
		N'Activewear',
		N'Activewear'
	),
	(
		N'Belts',
		N'Belts'
	),
	(
		N'Bags',
		N'Bags'
	),
	(
		N'Swimwear',
		N'Swimwear'
	),
	(
		N'Latest',
		N'Latest Collections'
	);
END


DECLARE @Count INT = 0;
DECLARE @MaxCount INT = 20;

WHILE @Count < @MaxCount
BEGIN

	INSERT INTO [dbo].[Products]
	(
		[BrandId],
		[Name],
		[Description],
		[InStock],
		[Price],
		[SKU]
	)
	SELECT
		[Id],
		NEWID(),
		NEWID(),
		30,
		20.00,
		NEWID()
	FROM [dbo].[Brands]
	ORDER BY NEWID()
	OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY;

	SET @Count = @Count + 1;
END

COMMIT TRANSACTION

SELECT * FROM @Outputs;