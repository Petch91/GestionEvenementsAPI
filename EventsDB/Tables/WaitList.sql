CREATE TABLE [dbo].[WaitList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CosplayerId] INT NOT NULL, 
    [EventId] INT NOT NULL,
    CONSTRAINT [FK_WaitList_Users] FOREIGN KEY ([CosplayerId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_WaitList_Event] FOREIGN KEY ([EventId]) REFERENCES [Event]([Id])
)
