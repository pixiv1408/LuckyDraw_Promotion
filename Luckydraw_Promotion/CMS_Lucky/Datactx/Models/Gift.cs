using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class Gift
    {
        public Gift()
        {
            CampGifts = new HashSet<CampGift>();
        }
        [Key]
        public int giftId { get; set; }
        public string giftName { get; set; } = null!;
        public string giftDescription { get; set; } = null!;
        public DateTime giftCreatedDate { get; set; }


        public ICollection<CampGift> CampGifts { get; set; } 
    }
}
