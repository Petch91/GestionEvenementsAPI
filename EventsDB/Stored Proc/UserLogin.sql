CREATE PROCEDURE [dbo].[UserLogin]
	@email VARCHAR(100),
	@pwd VARCHAR(100)
AS
BEGIN
	DECLARE @salt VARCHAR(MAX)
	SELECT @salt =  [Value] FROM salt where Id = (Select SaltId FROM Users WHERE Email = @email)

	DECLARE @pwdHash VARBINARY(64)
	SET @pwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @email, dbo.GetSecretKey()))

	SELECT Id, Nickname, Email, RoleId ,LastName ,FirstName, Allergie,GSM,InfoSupp
	FROM Users 
	WHERE Email = @email AND PasswordHash = @pwdHash

END