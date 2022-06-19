using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.DTO
{
    public class CustomerDTO
    {
        public int cusId { get; set; }
        public string cusName { get; set; } 
        public string? cusPhone { get; set; }
        public string? cusAddress { get; set; }
        public DateTime? cusDoB { get; set; }
        public bool? cusStatus { get; set; } 
    }
}
