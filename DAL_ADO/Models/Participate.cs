using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Models
{
   public class Participate
   {
      public int Id { get; set; }
      public int CosplayerId { get; set; }
      public int EventId { get; set; }
      public DateTime Date { get; set; }
      public bool Presence { get; set; }
   }
}
