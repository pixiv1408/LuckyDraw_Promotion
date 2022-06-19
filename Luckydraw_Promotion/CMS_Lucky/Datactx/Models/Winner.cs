using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class Winner
    {
        [Key]
        public int winId { get; set; }
        public DateTime winDate { get; set; }
        public bool winSentGift { get; set; } = false;
        public string winAddressReceivedGift { get; set; } = null!;



        public int cgcId { get; set; }
        public int cusId { get; set; }
        public CampaignCodeGift CampaignCodeGift { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
    }
}
