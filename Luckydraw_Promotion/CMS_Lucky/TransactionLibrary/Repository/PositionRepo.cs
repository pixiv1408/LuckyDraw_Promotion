using Datactx.Dbcontext;
using Datactx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.Interface;

namespace TransactionLibrary.Repository
{
    internal class PositionRepo : BaseRepo<Position>, IPositionRepo
    {
        public PositionRepo(DatabaseContext data) : base(data)
        {

        }
    }
}
