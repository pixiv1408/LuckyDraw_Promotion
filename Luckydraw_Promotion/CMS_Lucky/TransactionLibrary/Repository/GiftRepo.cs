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
    public class GiftRepo : BaseRepo<Gift>, IGiftRepo
    {
        public GiftRepo(DatabaseContext data) : base(data)
        {

        }
    }
}
