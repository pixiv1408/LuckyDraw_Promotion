using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class CampaignCode
    {
        public CampaignCode()
        {
            ScannedOrSpins = new HashSet<ScannedOrSpin>();
            
        }
        [Key]
        public int ccId { get; set; }
        public string ccCode { get; set; } = null!;
        public DateTime ccCreatedDate { get; set; }
        public int camId { get; set; }
        public Campaign Campaign { get; set; } = null!;



        public ICollection<ScannedOrSpin> ScannedOrSpins { get; set; }

    }
}
