using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.Response
{
    public class CampaignCodeGiftRP
    {
        public int cgcId { get; set; }
        public string cgcCode { get; set; }
        public DateTime cgcCreatedDate { get; set; }
        public bool cgcActive { get; set; }
        public int cgId { get; set; }
    }
}
