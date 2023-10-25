using DAL_ADO.Interfaces;
using DAL_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Services
{
   public class UserService : BaseService<int, User>, IUserService
   {
      public UserService(SqlConnection cnx) : base(cnx)
      {
      }

      public override User Create(User entity)
      {
         throw new NotImplementedException();
      }

      public override User Mapper(SqlDataReader record)
      {
         return new User
         {
            Id = (int)record["Id"],
            Email = (string)record["Email"],
            LastName = (string)record["LastName"],
            FirstName = (string)record["FirstName"],
            GSM = record["GSM"] == DBNull.Value ? null : (string)record["GSM"],
            NickName = record["NickName"] == DBNull.Value ? null : (string)record["NickName"],
            Allergie = record["Allergie"] == DBNull.Value ? null : (string)record["Allergie"],
            InfoSupp = record["InfoSupp"] == DBNull.Value ? null : (string)record["InfoSupp"],
            Role = new Role { Id = (int)record["RoleId"] }
         };
      }

      public override void Update(User entity)
      {
         string sql = "UPDATE Users SET LastName = @lastname, FirstName = @firstname, GSM = @GSM, NickName = @nickname, Allergie = @allergies, InfoSupp = @infosupp WHERE Id = @idUser";
         SqlParameter[] parameters =
         {
            GenerateParameter("GSM",entity.GSM),
            GenerateParameter("lastname",entity.LastName),
            GenerateParameter("firstname",entity.FirstName),
            GenerateParameter("nickname",entity.NickName),
            GenerateParameter("allergies",entity.Allergie),
            GenerateParameter("infosupp",entity.InfoSupp),
            GenerateParameter("idUser",entity.Id)
         };
         ExecuteNonQuery(sql, parameters);
      }

      public User Login(string email, string pwd)
      {
         string sql = "UserLogin";
         SqlParameter[] parameters =
         {
            GenerateParameter("email",email),
            GenerateParameter("pwd", pwd)
         };
         User u = ExecuteReaderOneElement<User>(sql, parameters, reader => Mapper(reader), CommandType.StoredProcedure);
         if (u is null)
         {
            throw new Exception("Login Failed: Email or password is wrong");
         }
         return u;

      }

      public bool Register(string email, string pwd, string lastName, string firstName)
      {
         string sql = "UserRegister";
         SqlParameter[] parameters =
         {
            GenerateParameter("email",email),
            GenerateParameter("password", pwd),
            GenerateParameter("lastname", lastName),
            GenerateParameter("firstname", firstName)

         };
         return ExecuteNonQuery(sql, parameters, CommandType.StoredProcedure) > 0;

      }

      public bool SetRole(int idUser, int idRole)
      {
         string sql = "UPDATE Users SET RoleId = @idRole WHERE Id = @idUser";
         SqlParameter[] parameters =
         {
            GenerateParameter("idRole",idRole),
            GenerateParameter("idUser",idUser)
         };

         return ExecuteNonQuery(sql, parameters) > 0;

      }
      public void AddInfoSupp(int idUser, string GSM, string nickname, string allergies, string infosupp)
      {
         string sql = "UPDATE Users SET GSM = @GSM, NickName = @nickname, Allergie = @allergies, InfoSupp = @infosupp WHERE Id = @idUser";
         SqlParameter[] parameters =
         {
            GenerateParameter("GSM",GSM),
            GenerateParameter("idUser",idUser),
            GenerateParameter("nickname",nickname),
            GenerateParameter("allergies",allergies),
            GenerateParameter("infosupp",infosupp)
         };
         ExecuteNonQuery(sql, parameters);
      }

   }
}
