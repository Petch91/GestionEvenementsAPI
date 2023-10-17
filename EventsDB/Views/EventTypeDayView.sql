CREATE VIEW [dbo].[EventTypeDayView]
	AS SELECT etd.Id , etd.[Date], etd.TypeId, et.[Name], etd.EventId
		FROM EventTypeDay etd 
		join EventType et
		on etd.TypeId = et.Id
