CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] VARCHAR(100) NOT NULL, 
    [PasswordHash] VARBINARY(64) NOT NULL, 
    [RoleId] INT NOT NULL DEFAULT 1, 
    [SaltId] INT NOT NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    [FirstName] VARCHAR(100) NOT NULL, 
    [GSM] VARCHAR(10) NULL, 
    [NickName] VARCHAR(100) NULL, 
    [Allergie] VARCHAR(200) NULL, 
    [InfoSupp] VARCHAR(200) NULL, 
    CONSTRAINT [FK_Users_Role] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id]), 
    CONSTRAINT [FK_Users_Salt] FOREIGN KEY ([SaltId]) REFERENCES [Salt]([Id])
)
