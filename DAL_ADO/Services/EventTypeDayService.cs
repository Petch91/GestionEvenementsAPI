using DAL_ADO.Interfaces;
using DAL_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Services
{
   public class EventTypeDayService : BaseService<int, EventTypeDay> , IEventTypeDayService
   {
      public EventTypeDayService(SqlConnection cnx) : base(cnx)
      {
      }

      public override EventTypeDay Create(EventTypeDay entity)
      {
         string sql = "CreateEventTypeDay";
         SqlParameter[] parameters =
{
            GenerateParameter("typeId", entity.Type.Id),
            GenerateParameter("eventId", entity.EventId),
            GenerateParameter("date", entity.Date)

         };
         return ExecuteReaderOneElement<EventTypeDay>(sql, parameters, reader => Mapper(reader), CommandType.StoredProcedure);
      }

      public override EventTypeDay Mapper(SqlDataReader record)
      {
         return new EventTypeDay
         {
            Id = (int)record["Id"],
            EventId = (int)record["EventId"],
            Date = (DateTime)record["Date"],
            Type = new EventType { Id = (int)record["TypeId"], Name = (string)record["Name"] }
         };
      }

      public override void Update(EventTypeDay entity)
      {
         throw new NotImplementedException();
      }
   }
}
