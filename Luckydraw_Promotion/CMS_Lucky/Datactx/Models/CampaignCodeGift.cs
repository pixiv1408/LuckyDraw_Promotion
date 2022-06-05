using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class CampaignCodeGift
    {
        public CampaignCodeGift()
        {
            Winners = new HashSet<Winner>();

        }
        [Key]
        public int cgcId { get; set; }
        public string cgcCode { get; set; } = null!;
        public DateTime cgcCreatedDate { get; set; }
        public bool cgcActive { get; set; } = false;



        public int cgId { get; set; }
        public CampGift CampGift { get; set; } = null!;


        public ICollection<Winner> Winners { get; set; }
    }
}
