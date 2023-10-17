INSERT INTO Role([Name]) VALUES('User')
INSERT INTO Role([Name]) VALUES('Cosplayer')
INSERT INTO Role([Name]) VALUES('Modo')
INSERT INTO Role([Name]) VALUES('Admin')

exec UserRegister 'admin@gmail.com', 'Pouyette91', 'Admin','Admin'

UPDATE Users SET RoleId = 3 WHERE Id = 1

INSERT INTO EventType VALUES ('Medieval Fantastic'),('Manga'),('Star Wars'),('Heroic Fantasy')

INSERT INTO [Status] VALUES ('En attente de validation'),('Confirmé'),('Passé')

INSERT INTO [Event]([Name], StartDate, EndDate, [Location], Adress) VALUES('MIA','05/10/2023','07/10/2023','test','Bruxelles')

INSERT INTO EventTypeDay(TypeId, EventId, [Date]) VALUES(1,1,'05/10/2023')
INSERT INTO EventTypeDay(TypeId, EventId, [Date]) VALUES(2,1,'06/10/2023')
INSERT INTO EventTypeDay(TypeId, EventId, [Date]) VALUES(3,1,'07/10/2023')