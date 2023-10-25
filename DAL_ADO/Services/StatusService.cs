using DAL_ADO.Interfaces;
using DAL_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Services
{
   public class StatusService : BaseService<int, Status>, IStatusService
   {
      public StatusService(SqlConnection cnx) : base(cnx)
      {
      }

      public override Status Create(Status entity)
      {
         throw new NotImplementedException();
      }

      public override Status Mapper(SqlDataReader record)
      {
         return new Status
         {
            Id = (int)record["Id"],
            Name = (string)record["Name"]
         };
      }

      public override void Update(Status entity)
      {
         throw new NotImplementedException();
      }
   }
}
