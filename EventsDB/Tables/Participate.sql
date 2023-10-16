CREATE TABLE [dbo].[Participate]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CosplayerId] INT NOT NULL, 
    [EventId] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [Presence] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Participate_Users] FOREIGN KEY ([CosplayerId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Participate_Event] FOREIGN KEY ([EventId]) REFERENCES [Event]([Id])
)
