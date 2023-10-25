using DAL_ADO.Interfaces;
using DAL_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Services
{
   public class EventService : BaseService<int, Event> , IEventService
   {
      public EventService(SqlConnection cnx) : base(cnx)
      {
      }

      public override Event Create(Event entity)
      {

         string sql = "INSERT INTO Event (Name, StartDate, EndDate, Location, Adress)" +
                      " OUTPUT INSERTED.* " +
                      " VALUES(@name, @startDate, @endDate, @location, @adress)";
         SqlParameter[] parameters =
         {
            GenerateParameter("name", entity.Name),
            GenerateParameter("startDate", entity.StartDate),
            GenerateParameter("endDate", entity.EndDate),
            GenerateParameter("location", entity.Location),
            GenerateParameter("adress", entity.Adress)
         };
         return ExecuteReaderOneElement<Event>(sql, parameters, reader => Mapper(reader));

      }

      public override Event Mapper(SqlDataReader record)
      {
         return new Event
         {
            Id = (int)record["Id"],
            Name = (string)record["Name"],
            StartDate = (DateTime)record["StartDate"],
            EndDate = (DateTime)record["EndDate"],
            Location = (string)record["Location"],
            Adress = (string)record["Adress"],
            Status = new Status { Id = (int)record["StatusId"] }
         };
      }

      public override void Update(Event entity)
      {
         throw new NotImplementedException();
      }


   }
}
