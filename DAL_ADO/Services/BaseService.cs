using DAL_ADO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Services
{
   public abstract class BaseService<TKey, TEntity> : AdoService, IBaseService<TKey, TEntity> where TEntity : class
   {
      //private string _connectionString = @"Data Source=DESKTOP-9B27V2B;Initial Catalog=GameDB2;Integrated Security=True;";


      protected BaseService(SqlConnection cnx) : base(cnx)
      {

      }

      protected SqlParameter GenerateParameter(string name, object value)
      {
         return new SqlParameter(name, value ?? DBNull.Value);
      }
      public abstract TEntity Mapper(SqlDataReader record);

      public abstract TEntity Create(TEntity entity);


      public virtual TEntity ReadOne(TKey id, string tablename = "")
      {
         if (string.IsNullOrWhiteSpace(tablename))
         {
            tablename = typeof(TEntity).Name;
         }
         string sql = "SELECT * FROM " +
                        tablename +
                      " WHERE Id = @id";
         SqlParameter[] parameters =
         {
            GenerateParameter("id",id),
         };
         TEntity entity = ExecuteReaderOneElement<TEntity>(sql, parameters, reader => Mapper(reader));
         return entity;
      }

      public virtual IEnumerable<TEntity> ReadAll(string tablename = "")
      {
         if (string.IsNullOrWhiteSpace(tablename))
         {
            tablename = typeof(TEntity).Name;
         }
         string sql = "SELECT * FROM " + tablename;

         IEnumerable<TEntity> entities = ExecuteReader<TEntity>(sql, reader => Mapper(reader));
         return entities;
      }

      public abstract void Update(TEntity entity);


      public virtual void Delete(TKey id, string tablename = "")
      {
         if (string.IsNullOrWhiteSpace(tablename))
         {
            tablename = typeof(TEntity).Name;
         }
         string sql = "DELETE FROM " +
               tablename +
             " WHERE Id = @id";
         SqlParameter[] parameters =
         {
            GenerateParameter("id",id),
         };
         ExecuteNonQuery(sql, parameters);
      }
   }
}
