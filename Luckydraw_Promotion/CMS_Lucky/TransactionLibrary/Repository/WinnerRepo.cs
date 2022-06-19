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
    public class WinnerRepo : BaseRepo<Winner>, IWinnerRepo
    {
        public WinnerRepo(DatabaseContext data) : base(data)
        {

        }
    }
}
