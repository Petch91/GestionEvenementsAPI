CREATE PROCEDURE [dbo].[UserRegister]
	@email VARCHAR(100),
	@password VARCHAR(100),
	@lastname VARCHAR(100),
	@firstname VARCHAR(100)
AS
BEGIN

	DECLARE @salt TABLE (id INT, valu VARCHAR(MAX))

	INSERT INTO Salt ([Value])
	OUTPUT INSERTED.id, INSERTED.[Value] INTO @salt (id, valu)
	VALUES (CONCAT(NEWID(), NEWID(), NEWID()))


	DECLARE @pwdHash VARBINARY(64)
	SET @pwdHash = HASHBYTES('SHA2_512', CONCAT((select valu from @salt), @password, @email, dbo.GetSecretKey()))

	INSERT INTO Users (Email, PasswordHash, SaltId, LastName,FirstName) VALUES
	(@email, @pwdHash, (select id from @salt), @lastname, @firstname)
END