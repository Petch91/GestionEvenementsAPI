using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ADO.Interfaces
{
   public interface IBaseService<TKey, TEntity> where TEntity : class
   {
      TEntity Create(TEntity entity);
      TEntity ReadOne(TKey id, string tablename = "");
      IEnumerable<TEntity> ReadAll(string tablename = "");
      void Update(TEntity entity);
      void Delete(TKey id,string tablename = "");
   }
}
