CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NOT NULL, 
    [Location] VARCHAR(50) NOT NULL, 
    [Adress] VARCHAR(200) NOT NULL, 
    [StatusId] INT NOT NULL, 
    CONSTRAINT [FK_Event_Status] FOREIGN KEY ([StatusId]) REFERENCES [Status]([Id])
)
