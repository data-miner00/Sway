CREATE SCHEMA internal;

GO;

ALTER SCHEMA internal TRANSFER OBJECT::dbo.SystemSetting;

GO;
