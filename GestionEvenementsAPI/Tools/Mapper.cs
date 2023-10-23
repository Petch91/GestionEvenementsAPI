using DAL_ADO.Models;
using GestionEvenementsAPI.Models;
using GestionEvenementsAPI.Models.Form;

namespace GestionEvenementsAPI.Tools
{
    public static class Mapper
   {
      public static Event ToDal(this EventCreate eventCreate)
      {
         return new Event
         {
            Name = eventCreate.Name,
            StartDate = eventCreate.StartDate,
            EndDate = eventCreate.EndDate,
            Location = eventCreate.Location,
            Adress = eventCreate.Adress
         };
      }
      public static UserView ToUserView(this User user)
      {
         return new UserView { Id = user.Id, NickName = user.NickName };
      }
   }
}
