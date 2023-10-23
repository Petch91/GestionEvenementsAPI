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
   public class RoleService : BaseService<int, Role>, IRoleService
   {
      public RoleService(SqlConnection cnx) : base(cnx)
      {
      }

      public override Role Create(Role entity)
      {
         throw new NotImplementedException();
      }

      public override Role Mapper(SqlDataReader record)
      {
         return new Role
         {
            Id = (int)record["Id"],
            Name = (string)record["Name"]
         };
      }

      public override void Update(Role entity)
      {
         throw new NotImplementedException();
      }
   }
}
