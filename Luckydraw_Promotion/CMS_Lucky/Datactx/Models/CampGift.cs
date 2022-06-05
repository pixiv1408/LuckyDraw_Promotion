using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class CampGift
    {
        public CampGift()
        {
            CampaignCodeGifts = new HashSet<CampaignCodeGift>();
            Rulesforgifts = new HashSet<Rulesforgift>();

        }
        [Key]
        public int cgId { get; set; }
        public int cgGiftCodeCount { get; set; }



        public int camId { get; set; }
        public int giftId { get; set; }
        public Campaign Campaign { get; set; } = null!;
        public Gift Gift { get; set; } = null!;


        public ICollection<CampaignCodeGift> CampaignCodeGifts { get; set; } 
        public ICollection<Rulesforgift> Rulesforgifts { get; set; } 
    }
}
