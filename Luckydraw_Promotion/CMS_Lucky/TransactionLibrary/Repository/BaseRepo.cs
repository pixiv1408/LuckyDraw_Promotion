using Datactx.Dbcontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.Interface;

namespace TransactionLibrary.Repository
{
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        public BaseRepo(DatabaseContext data)
        {
            _data = data;
            _dbset = _data.Set<T>();
        }
        private DbSet<T> _dbset { get; }
        private DatabaseContext _data { get; }
        
        //All
        public async Task<List<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }
        //ID
        public async Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }
        //Insert
        public async void Insert(T entity)
        {
            await _dbset.AddAsync(entity);
        }
        //Update
        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
        //Delete
        public async void Delete(int id)
        {
            var find = await _dbset.FindAsync(id);
            _dbset.Remove(find);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _dbset.AnyAsync(expression);
        }
        

    }
}

