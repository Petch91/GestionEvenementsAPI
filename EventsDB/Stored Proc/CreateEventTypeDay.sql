CREATE PROCEDURE [dbo].[CreateEventTypeDay]
	@typeId INT,
	@eventId INT,
	@date DATETIME2(7)
AS
BEGIN

	DECLARE @eventType TABLE (Id INT, TypeId INT, EventId INT, [Date] DATETIME2(7))

	INSERT INTO EventTypeDay(TypeId,EventId,[Date])
	OUTPUT INSERTED.* INTO @eventType (Id, TypeId, EventId, [Date])
	VALUES (@typeId , @eventId, @date)

	SELECT etd.Id , etd.[Date], etd.TypeId, et.[Name], etd.EventId 
		FROM @eventType etd 
		join EventType et
		on etd.TypeId = et.Id
END