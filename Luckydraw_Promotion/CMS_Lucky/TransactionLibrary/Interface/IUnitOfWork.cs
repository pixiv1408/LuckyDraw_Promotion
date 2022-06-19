using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IPositionRepo PositionRepo { get; }
        ICustomerRepo CustomerRepo { get; }
        IUserRepo UserRepo { get; }
        public void save();
    }
}
