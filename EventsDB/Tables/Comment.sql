CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Content] VARCHAR(MAX) NOT NULL, 
    [PostDate] DATETIME2 NOT NULL, 
    [UserId] INT NOT NULL, 
    [EventId] INT NOT NULL, 
    CONSTRAINT [FK_Comment_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Comment_Event] FOREIGN KEY ([EventId]) REFERENCES [Event]([Id])
)
