using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.Response
{
    public class UserRP
    {
        public int userId { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
    }
}
