using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.Response
{
    public class WinnerRP
    {
        public int winId { get; set; }
        public DateTime winDate { get; set; }
        public bool winSentGift { get; set; }
        public string winAddressReceivedGift { get; set; }
        public int cgcId { get; set; }
        public int cusId { get; set; }
    }
}
