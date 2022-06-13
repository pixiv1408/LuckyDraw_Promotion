using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.Interface
{
    public interface IBaseRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(String id);
        Task<T> GetById(int id);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        void Delete(String id);
        void Delete(int id);
        void Update(T entity);
        void Insert(T entity);
    }
}
