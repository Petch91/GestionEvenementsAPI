CREATE TABLE [dbo].[EventTypeDay]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeId] INT NOT NULL, 
    [EventId] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_EventTypeDay_EventType] FOREIGN KEY ([TypeId]) REFERENCES [EventType]([Id]), 
    CONSTRAINT [FK_EventTypeDay_Event] FOREIGN KEY ([EventId]) REFERENCES [Event]([Id])
)
