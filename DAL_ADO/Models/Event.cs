using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Models
{
   public class Event
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public DateTime StartDate { get; set; }  
      public DateTime EndDate { get; set; }
      public string Location { get; set; }
      public string Adress { get; set; }
      public Status Status { get; set; }
      public List<EventTypeDay> TypeByDays { get; set; }

      public void AddTypeByDay(IEnumerable<EventTypeDay> typeDays)
      {
         TypeByDays = new List<EventTypeDay>();
         foreach (EventTypeDay etd in typeDays)
         {
            this.TypeByDays.Add(etd);
         }
      }
   }
}
