using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Models
{
   public class User
   {
      public int Id { get; set; }
      public string Email { get; set; }
      public Role? Role { get; set; }
      public string LastName { get; set; }
      public string FirstName { get; set; }
      public string? GSM { get; set; }
      public string? NickName { get; set; }
      public string? Allergie { get; set; }
      public string? InfoSupp { get; set; }
   }
}
