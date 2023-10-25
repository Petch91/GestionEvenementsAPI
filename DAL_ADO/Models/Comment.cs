using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Models
{
   public class Comment
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public DateTime PostDate { get; set; }
      public int UserId { get; set; }
      public int EventId { get; set; }
   }
}
