USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [SwayUser]    Script Date: 27/7/2024 3:12:38 PM ******/
CREATE LOGIN [SwayUser] WITH
	PASSWORD=N'password',
	DEFAULT_DATABASE=[master],
	DEFAULT_LANGUAGE=[us_english],
	CHECK_EXPIRATION=OFF,
	CHECK_POLICY=OFF
GO

ALTER LOGIN [SwayUser] DISABLE
GO

