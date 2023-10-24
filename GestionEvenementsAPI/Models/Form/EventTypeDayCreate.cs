namespace GestionEvenementsAPI.Models.Form
{
   public class EventTypeDayCreate
   {
      public int EventId { get; set; }
      public int TypeId { get; set; }
      public DateTime Date { get; set; }
   }
}
