using DAL_ADO.Models;

namespace DAL_ADO.Interfaces
{
   public interface IUserService : IBaseService<int, User>
   {
      User Login(string email, string pwd);
      bool Register(string email, string pwd, string lastName, string firstName);
      bool SetRole(int idUser, int idRole);
   }
}