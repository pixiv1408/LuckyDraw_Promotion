using Datactx.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.Interface;
using TransactionLibrary.Repository;

namespace TransactionLibrary.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DatabaseContext _data;
        public UnitOfWork(DatabaseContext data)
        {
            _data = data;
            PositionRepo = new PositionRepo(_data);
            CustomerRepo = new CustomerRepo(_data);
            UserRepo = new UserRepo(_data);
        }

        public IPositionRepo PositionRepo { get; private set; }
        public ICustomerRepo CustomerRepo { get; private set; }
        public IUserRepo UserRepo { get; private set; } 

        public void Dispose()
        {
            _data?.Dispose();
        }

        public void save()
        {
            _data.SaveChanges();

        }
    }
}
