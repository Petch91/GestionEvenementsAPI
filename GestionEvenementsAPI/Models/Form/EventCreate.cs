using DAL_ADO.Models;

namespace GestionEvenementsAPI.Models.Form
{
   public class EventCreate
   {
      public string Name { get; set; }
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }
      public string Location { get; set; }
      public string Adress { get; set; }
      public List<EventTypeDay> TypeByDay { get; set; }
   }
}
