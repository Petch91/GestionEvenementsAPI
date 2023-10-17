using DAL_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Services
{
   internal class EventTypeService : BaseService<int, EventType>
   {
      public EventTypeService(SqlConnection cnx) : base(cnx)
      {
      }

      public override EventType Create(EventType entity)
      {
         throw new NotImplementedException();
      }

      public override EventType Mapper(SqlDataReader record)
      {
         throw new NotImplementedException();
      }

      public override void Update(EventType entity)
      {
         throw new NotImplementedException();
      }
   }
}
