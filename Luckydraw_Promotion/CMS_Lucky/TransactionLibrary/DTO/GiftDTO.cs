using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.DTO
{
    public class GiftDTO
    {
        public int giftId { get; set; }
        public string giftName { get; set; }
        public string giftDescription { get; set; } 
        public DateTime giftCreatedDate { get; set; }
    }
}
