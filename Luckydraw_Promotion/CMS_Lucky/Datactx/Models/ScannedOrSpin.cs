using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class ScannedOrSpin
    {
        [Key]
        public int sosId { get; set; }
        public DateTime? scannedDate { get; set; }
        public DateTime? spinDate { get; set; }



        public int ccId { get; set; }
        public int cusId { get; set; }
        public CampaignCode? CampaignCode { get; set; }
        public Customer? Customer { get; set; }
    }
}
