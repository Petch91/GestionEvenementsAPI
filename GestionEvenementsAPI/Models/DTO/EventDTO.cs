using DAL_ADO.Models;

namespace GestionEvenementsAPI.Models.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
        public List<EventTypeDay> TypeByDays { get; set; }
    }
}
